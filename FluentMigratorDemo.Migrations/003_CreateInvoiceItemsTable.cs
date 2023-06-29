using FluentMigrator;

namespace FluentMigratorDemo.Migrations;

[Migration(3)]
public class CreateInvoiceItemsTable : Migration
{
    public override void Up()
    {
        Create.Table("InvoiceItem")
            .WithColumn("Id").AsInt64().PrimaryKey().Identity()
            .WithColumn("Description").AsString(3000).NotNullable()
            .WithColumn("Quantity").AsInt64().NotNullable()
            .WithColumn("Price").AsDecimal().NotNullable()
            .WithColumn("InvoiceId").AsInt64().NotNullable();

        Create.ForeignKey("fk_invoice_invoiceitem")
            .FromTable("InvoiceItem").ForeignColumn("InvoiceId")
            .ToTable("Invoices").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.ForeignKey("fk_invoice_invoiceitem");
        Delete.Table("InvoiceItem");
    }
}