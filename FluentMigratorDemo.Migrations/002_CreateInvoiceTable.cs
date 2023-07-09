using FluentMigrator;

namespace FluentMigratorDemo.Migrations;

[Migration(2)]
public class CreateInvoiceTable : Migration
{
    public override void Up()
    {
        Create.Table("Invoices")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("InvoiceNumber").AsString(12).NotNullable()
            .WithColumn("InvoiceDt").AsDate().NotNullable()
            .WithColumn("BillingAddress").AsString().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("Invoices");
    }
}