using Microsoft.EntityFrameworkCore.Migrations;

namespace BShop.Infrastructure.Migrations
{
    public partial class CustomMigr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //declare user-defined table type
            migrationBuilder.Sql(@"CREATE type UserDefCartItems as table
                                (
                                    itemID nvarchar(450) not null,
                                    amount int not null
                                )");

            string PurchaseStoredProcedure = @"CREATE procedure [dbo].[purchase](
								@cartItems [UserDefCartItems] readonly,
								@creditnum nvarchar(30),
								@BuyerID nvarchar(50),
								@result bit = 0 out
								)
								as begin
								set @result = 0
								--Start Transaction
								BEGIN TRY
									BEGIN TRANSACTION BUY
										declare @Fee int

										--calculate price and deduct items
										Update dbo.BShopItems
										set BShopItems.Amount = (BShopItems.Amount - cI2.amount), 
										@Fee =
										(Select SUM(BShopItems.Price*cI.amount)
												from @cartItems cI join BShopItems
												on BShopItems.Id = cI.itemID
												where BShopItems.Amount >= cI.amount
										)
										from BShopItems join @cartItems cI2
										on BShopItems.Id = cI2.itemID
										where BShopItems.Amount >= cI2.amount

										--todo: if @fee != amount... abort transaction

										--if ALL items can't be bought, ROLLBACK and return 0
										if @@ROWCOUNT != (select count(*) from @cartItems)
											begin
												ROLLBACK TRANSACTION BUY
												--print('escape!')
												set @result = 0;
											end
										else
											begin
												/*  later code here for doing transaction through bank gateways  
												*/
												--print('hit!1')
												-- insert transaction data
												declare @TmpID1 int = FLOOR(RAND()*1000000)

												insert
												into dbo.Transactions (TransID,TransactionTime,CreditNum, Fee, BuyerID) --no cartID
												values
												(
												@TmpID1,
												GETDATE(),
												@creditnum,
												@Fee,
												@BuyerID
												)

												--print('hit!2')

												declare @TmpID2 int = FLOOR(RAND()*1000000)

												-- insert shopping data
												insert
												into dbo.shoppingCarts (CartID,TransID,TotalCost)
												values (@TmpID2,@TmpID1,@Fee)
												--print('hit!3');

												insert into dbo.CartItems (BShopItemID,ShoppingCartID,Amount)
												select itemID,@TmpID2,amount
													from @cartItems

												--print('hit!4')
												COMMIT TRANSACTION BUY
												set @result = 1
											end
								END TRY
								BEGIN CATCH
									IF @@TRANCOUNT > 0
										ROLLBACK TRANSACTION BUY
									set @result = 0
									--print(CONVERT(varchar(20), ERROR_NUMBER()) + ' ,  ' + ERROR_MESSAGE())
								END CATCH
								end";
            migrationBuilder.Sql(PurchaseStoredProcedure);

            //CreateStoredProcedure();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP TYPE [dbo].[UserDefCartItems]");
            migrationBuilder.Sql(@"DROP PROCEDURE [dbo].[purchase]");
        }
    }
}
