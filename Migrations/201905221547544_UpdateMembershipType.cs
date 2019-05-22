namespace solo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            //Sql("UPDATE MembershipTypes " +
            //    "SET Name = ( " +
            //    "CASE  " +
            //    "WHEN DurationInMonth = 0 THEN 'Pay as you Go' " +
            //    "WHEN DurationInMonth = 1 THEN 'Monthly' " +
            //    "WHEN DurationInMonth = 3 THEN 'Qaterly' " +
            //    "WHEN DurationInMonth = 4 THEN 'Yearly' " +
            //    "ELSE 'Undefined' "+
            //    "END );");

            Sql("UPDATE MembershipTypes " +
              "SET Name = 'Pay as you Go 2' WHERE DurationInMonth = 0 ");
            Sql("UPDATE MembershipTypes " +
               "SET Name = 'Monthly' WHERE DurationInMonth = 1");
            Sql("UPDATE MembershipTypes " +
               "SET Name = 'Quaterly' WHERE DurationInMonth = 3");
            Sql("UPDATE MembershipTypes " +
               "SET Name = 'Yearly' WHERE DurationInMonth = 12");

            }
        
        public override void Down()
        {
        }
    }
}
