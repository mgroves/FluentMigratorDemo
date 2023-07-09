using FluentMigrator;

namespace FluentMigratorDemo.Migrations;

[Migration(3)]
public class CreateInvoiceItemsTable : Migration
{
    public override void Up()
    {
        // For SQLite, you must create foreign keys during CREATE TABLE
        IfDatabase("SQLite")
            .Create.Table("InvoiceItem")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Description").AsString(3000).NotNullable()
                .WithColumn("Quantity").AsInt64().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("InvoiceId").AsInt64().NotNullable()
                .ForeignKey("fk_invoice_invoiceitem",
                    "Id",
                    "InvoiceItem",
                    "Invoices");

        IfDatabase("SqlServer")
            .Create.Table("InvoiceItem")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Description").AsString(3000).NotNullable()
                .WithColumn("Quantity").AsInt64().NotNullable()
                .WithColumn("Price").AsDecimal().NotNullable()
                .WithColumn("InvoiceId").AsInt64().NotNullable();

        IfDatabase("SqlServer")
            .Create.ForeignKey("fk_invoice_invoiceitem")
                .FromTable("InvoiceItem").ForeignColumn("InvoiceId")
                .ToTable("Invoices").PrimaryColumn("Id");
    }

    public override void Down()
    {
        IfDatabase("SqlServer")
            .Delete
            .ForeignKey("fk_invoice_invoiceitem")
            .OnTable("InvoiceItem");

        Delete.Table("InvoiceItem");
    }
}