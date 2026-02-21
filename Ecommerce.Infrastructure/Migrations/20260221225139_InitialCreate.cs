using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "access_profile",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_profile", x => x.id);
                    table.CheckConstraint("CK_AccessProfile_Description_MinLength", "char_length(description) >= 3");
                    table.CheckConstraint("CK_AccessProfile_Name_MinLength", "char_length(name) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    url_key = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    logo_url = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    email_address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    mobile_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    Cnpj_Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_brand", x => x.id);
                    table.CheckConstraint("CK_Brand_Name_MinLength", "char_length(name) >= 2");
                    table.CheckConstraint("CK_Brand_UrlKey_Format", "url_key ~ '^[a-z0-9-]+$'");
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    url_key = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    display_order = table.Column<int>(type: "integer", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    ParentCategoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                    table.ForeignKey(
                        name: "FK_category_category_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "email_status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    flag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "entity_metadata",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    entity_code = table.Column<string>(type: "varchar(7)", fixedLength: true, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entity_metadata", x => x.id);
                    table.CheckConstraint("CK_EntityMetadata_Code_Positive", "char_length(entity_code) > 0");
                });

            migrationBuilder.CreateTable(
                name: "invoice_status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    flag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logistics_provider",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    cnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    email_address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    mobile_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    website = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    logo_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    Cnpj_Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistics_provider", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "logistics_status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    flag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistics_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    flag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_gateway",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    flag = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email_address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    mobile_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    telephone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    priority = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    environment_key = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    api_base_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_gateway", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "payment_status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    flag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_attribute", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "product_review_status",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    flag = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_review_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "stock_transaction_reason",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_transaction_reason", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "template_email",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    subject = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_template_email", x => x.id);
                    table.CheckConstraint("CK_TemplateEmail_Body_MinLength", "char_length(body) >= 3");
                    table.CheckConstraint("CK_TemplateEmail_Name_MinLength", "char_length(name) >= 3");
                    table.CheckConstraint("CK_TemplateEmail_Subject_MinLength", "char_length(subject) >= 3");
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    first_name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    last_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    full_name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    email_address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    mobile_phone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: false),
                    security_stamp = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    last_access = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DateAccessTry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    lockout_end = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_email_address_confirmed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                    table.CheckConstraint("CK_User_email_address_MinLength", "char_length(email_address) >= 5");
                    table.CheckConstraint("CK_User_FirstName_MinLength", "char_length(first_name) >= 2");
                    table.CheckConstraint("CK_User_FullName_MinLength", "char_length(full_name) >= 4");
                    table.CheckConstraint("CK_User_LastName_MinLength", "char_length(last_name) >= 2");
                    table.CheckConstraint("CK_User_UserName_MinLength", "char_length(user_name) >= 2");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    url_key = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    short_description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    full_description = table.Column<string>(type: "text", nullable: true),
                    brand_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_brand_brand_id",
                        column: x => x.brand_id,
                        principalTable: "brand",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "coupon",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    discount_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    usage_limit = table.Column<int>(type: "integer", nullable: false),
                    min_purchase_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coupon", x => x.id);
                    table.CheckConstraint("CK_Coupon_Dates", "expiration_date IS NULL OR expiration_date > start_date");
                    table.CheckConstraint("CK_Coupon_DiscountAmount", "discount_amount > 0");
                    table.CheckConstraint("CK_Coupon_Type_Enum", "type IN ('Percentage', 'FixedValue')");
                    table.ForeignKey(
                        name: "FK_coupon_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logistics_method",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    logistics_provider_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    tracking_url_template = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    estimated_delivery_time_hours = table.Column<int>(type: "integer", nullable: false),
                    base_price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    min_order_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    is_free_shipping = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    max_length = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    max_width = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    max_height = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    max_weight = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    requires_signature = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistics_method", x => x.id);
                    table.ForeignKey(
                        name: "FK_logistics_method_logistics_provider_logistics_provider_id",
                        column: x => x.logistics_provider_id,
                        principalTable: "logistics_provider",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment_method",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_gateway_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    gateway_flag = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    transaction_fee_percentage = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false, defaultValue: 0m),
                    icon_url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment_method", x => x.id);
                    table.ForeignKey(
                        name: "FK_payment_method_payment_gateway_payment_gateway_id",
                        column: x => x.payment_gateway_id,
                        principalTable: "payment_gateway",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_attribute_value",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_attribute_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_attribute_value", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_attribute_value_product_attribute_product_attribute~",
                        column: x => x.product_attribute_id,
                        principalTable: "product_attribute",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "email",
                columns: table => new
                {
                    email_address = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    subject = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    body = table.Column<string>(type: "text", nullable: false),
                    sent_attempts = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    last_error_message = table.Column<string>(type: "text", nullable: true),
                    sent_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    template_email_id = table.Column<Guid>(type: "uuid", nullable: false),
                    email_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    entity_metadata_id = table.Column<Guid>(type: "uuid", nullable: false),
                    reference_id = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FriendlyCode = table.Column<string>(type: "text", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_email", x => x.Id);
                    table.CheckConstraint("CK_Email_Body_MinLength", "char_length(body) >= 3");
                    table.CheckConstraint("CK_Email_MinLength", "char_length(email_address) >= 5");
                    table.CheckConstraint("CK_Email_Subject_MinLength", "char_length(subject) >= 3");
                    table.ForeignKey(
                        name: "FK_email_email_status_email_status_id",
                        column: x => x.email_status_id,
                        principalTable: "email_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_email_entity_metadata_entity_metadata_id",
                        column: x => x.entity_metadata_id,
                        principalTable: "entity_metadata",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_email_template_email_template_email_id",
                        column: x => x.template_email_id,
                        principalTable: "template_email",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "access_profile_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    access_profile_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_access_profile_user", x => x.id);
                    table.ForeignKey(
                        name: "FK_access_profile_user_access_profile_access_profile_id",
                        column: x => x.access_profile_id,
                        principalTable: "access_profile",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_access_profile_user_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    national_id = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    corporate_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    trade_name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    state_registration = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    customer_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    gender_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    birth_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    newsletter_subscribed = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    NationalId_Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.CheckConstraint("CK_Customer_NationalId_Length", "char_length(national_id) IN (11, 14)");
                    table.CheckConstraint("CK_Customer_Type_Enum", "customer_type IN ('Physical', 'Legal')");
                    table.CheckConstraint("CK_Customer_Type_Rules", "(customer_type = 'Physical' AND corporate_name IS NULL AND trade_name IS NULL AND state_registration IS NULL AND birth_date IS NOT NULL AND gender_type IS NOT NULL) OR (customer_type = 'Legal' AND corporate_name IS NOT NULL AND birth_date IS NULL AND gender_type IS NULL)");
                    table.CheckConstraint("CK_Gender_Type_Enum", "gender_type IN ('Male', 'Female', 'Other', 'NotShared')");
                    table.ForeignKey(
                        name: "FK_customer_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => new { x.product_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_product_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_category_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_variant",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    sku = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ean = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    length = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    width = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    height = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    weight = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    price = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_variant", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_variant_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    postal_code = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    street = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    complement = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    district = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    city = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    address_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.CheckConstraint("CK_Address_State_Validation", "(country = 'Brasil' AND char_length(state) = 2) OR (country <> 'Brasil')");
                    table.CheckConstraint("CK_Address_Type_Enum", "address_type IN ('Main', 'Delivery', 'Billing', 'Work')");
                    table.CheckConstraint("CK_Address_ZipCode_Validation", "(country = 'Brasil' AND char_length(postal_code) = 8) OR (country <> 'Brasil' AND char_length(postal_code) >= 3)");
                    table.ForeignKey(
                        name: "FK_address_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    items_total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    delivery_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    discount_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_payable_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    observation = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    confirmed_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    order_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    coupon_id = table.Column<Guid>(type: "uuid", nullable: true),
                    postal_code = table.Column<string>(type: "character varying(8)", maxLength: 8, nullable: false),
                    street = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    number = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    complement = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    district = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    city = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    state = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.CheckConstraint("CK_Order_delivery_amount_Positive", "delivery_amount >= 0");
                    table.CheckConstraint("CK_Order_DiscountAmount_Positive", "discount_amount >= 0");
                    table.CheckConstraint("CK_Order_ItemsTotalAmount_Positive", "items_total_amount >= 0");
                    table.CheckConstraint("CK_Order_TotalPayableAmount_Positive", "total_payable_amount >= 0");
                    table.ForeignKey(
                        name: "FK_order_coupon_coupon_id",
                        column: x => x.coupon_id,
                        principalTable: "coupon",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cart_item",
                columns: table => new
                {
                    product_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    added_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_item", x => new { x.customer_id, x.product_variant_id });
                    table.CheckConstraint("CK_CartItem_Quantity_Min", "quantity > 0");
                    table.ForeignKey(
                        name: "FK_cart_item_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cart_item_product_variant_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_variant_id = table.Column<Guid>(type: "uuid", nullable: true),
                    file_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    string_base64 = table.Column<string>(type: "text", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_main = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    display_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_image", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_image_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_image_product_variant_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "product_variant_attribute",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_attribute_value_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_variant_attribute", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_variant_attribute_product_attribute_value_product_a~",
                        column: x => x.product_attribute_value_id,
                        principalTable: "product_attribute_value",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_variant_attribute_product_variant_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stock",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    reserved_quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    min_quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock", x => x.id);
                    table.CheckConstraint("CK_Stock_MinQuantity_Positive", "min_quantity >= 0");
                    table.CheckConstraint("CK_Stock_Quantity_Positive", "quantity >= 0");
                    table.CheckConstraint("CK_Stock_Reserved_Positive", "reserved_quantity >= 0");
                    table.ForeignKey(
                        name: "FK_stock_product_variant_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    external_id = table.Column<string>(type: "text", nullable: true),
                    number = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    series = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    access_key = table.Column<string>(type: "character(44)", fixedLength: true, maxLength: 44, nullable: true),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    xml_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    pdf_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    error_message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    authorized_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true),
                    InvoiceStatusId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.id);
                    table.CheckConstraint("CK_Invoice_TotalAmount_Positive", "total_amount >= 0");
                    table.ForeignKey(
                        name: "FK_invoice_invoice_status_InvoiceStatusId",
                        column: x => x.InvoiceStatusId,
                        principalTable: "invoice_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoice_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "logistics",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    tracking_code = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    tracking_url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    logistics_cost = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    volume_number = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    observations = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    length = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    width = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    height = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    weight = table.Column<decimal>(type: "numeric(12,4)", precision: 12, scale: 4, nullable: false),
                    logistics_method_id = table.Column<Guid>(type: "uuid", nullable: false),
                    logistics_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    posted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    estimated_delivery_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    delivered_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logistics", x => x.id);
                    table.CheckConstraint("CK_Logistics_logistics_cost_Positive", "logistics_cost >= 0");
                    table.CheckConstraint("CK_Logistics_volume_number_Positive", "volume_number >= 1");
                    table.ForeignKey(
                        name: "FK_logistics_logistics_method_logistics_method_id",
                        column: x => x.logistics_method_id,
                        principalTable: "logistics_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logistics_logistics_status_logistics_status_id",
                        column: x => x.logistics_status_id,
                        principalTable: "logistics_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_logistics_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_item",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    unit_price_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_item", x => x.id);
                    table.CheckConstraint("CK_OrderItem_Quantity_Positive", "quantity > 0");
                    table.CheckConstraint("CK_OrderItem_TotalAmount_Positive", "total_amount >= 0");
                    table.CheckConstraint("CK_OrderItem_UnitPriceAmount_Positive", "unit_price_amount >= 0");
                    table.ForeignKey(
                        name: "FK_order_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_item_product_variant_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "payment",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    paid_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    installments = table.Column<int>(type: "integer", nullable: false),
                    paid_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    refunded_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true, defaultValue: 0.0m),
                    refunded_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    gateway_status_message = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    payment_link = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    receipt_link = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    external_transaction_id = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    authorization_code = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_gateway_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_method_id = table.Column<Guid>(type: "uuid", nullable: false),
                    payment_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payment", x => x.id);
                    table.CheckConstraint("CK_Payment_Installments_Positive", "installments > 0");
                    table.CheckConstraint("CK_Payment_PaidAmount_Positive", "paid_amount >= 0");
                    table.CheckConstraint("CK_Payment_RefundedAmount_Positive", "refunded_amount >= 0");
                    table.ForeignKey(
                        name: "FK_payment_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payment_payment_gateway_payment_gateway_id",
                        column: x => x.payment_gateway_id,
                        principalTable: "payment_gateway",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payment_payment_method_payment_method_id",
                        column: x => x.payment_method_id,
                        principalTable: "payment_method",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_payment_payment_status_payment_status_id",
                        column: x => x.payment_status_id,
                        principalTable: "payment_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_review",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    review_message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    rating = table.Column<int>(type: "integer", nullable: false),
                    helpful_votes = table.Column<int>(type: "integer", nullable: false),
                    reply_message = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    replied_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    product_review_status_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_review", x => x.id);
                    table.CheckConstraint("CK_ProductReview_HelpfulVotes", "helpful_votes >= 0");
                    table.CheckConstraint("CK_ProductReview_Rating", "rating >= 1 AND rating <= 5");
                    table.CheckConstraint("CK_ProductReview_ReplyMessage_MinLength", "reply_message IS NULL OR char_length(reply_message) >= 5");
                    table.CheckConstraint("CK_ProductReview_ReviewMessage_MinLength", "char_length(review_message) >= 5");
                    table.CheckConstraint("CK_ProductReview_Title_MinLength", "char_length(title) >= 3");
                    table.ForeignKey(
                        name: "FK_product_review_customer_customer_id",
                        column: x => x.customer_id,
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_review_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_product_review_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_review_product_review_status_product_review_status_~",
                        column: x => x.product_review_status_id,
                        principalTable: "product_review_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "stock_transaction",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_variant_id = table.Column<Guid>(type: "uuid", nullable: false),
                    order_id = table.Column<Guid>(type: "uuid", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false),
                    balance_after = table.Column<int>(type: "integer", nullable: false),
                    stock_transaction_type = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    stock_transaction_reason_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stock_transaction", x => x.id);
                    table.CheckConstraint("CK_Stock_BalanceAfter", "balance_after >= 0");
                    table.CheckConstraint("CK_Stock_Quantity", "quantity <> 0");
                    table.CheckConstraint("CK_Stock_Transaction_Type_Enum", "stock_transaction_type IN ('Input', 'Output', 'Neutral')");
                    table.ForeignKey(
                        name: "FK_stock_transaction_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_transaction_product_variant_product_variant_id",
                        column: x => x.product_variant_id,
                        principalTable: "product_variant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_transaction_stock_transaction_reason_stock_transactio~",
                        column: x => x.stock_transaction_reason_id,
                        principalTable: "stock_transaction_reason",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_stock_transaction_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "product_review_image",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_review_id = table.Column<Guid>(type: "uuid", nullable: false),
                    file_name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    string_base64 = table.Column<string>(type: "text", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    display_order = table.Column<int>(type: "integer", nullable: false, defaultValue: 0),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    friendly_code = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_by = table.Column<Guid>(type: "uuid", nullable: false),
                    modified_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    modified_by = table.Column<Guid>(type: "uuid", nullable: true),
                    deleted_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    deleted_by = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_review_image", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_review_image_product_review_product_review_id",
                        column: x => x.product_review_id,
                        principalTable: "product_review",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "email_status",
                columns: new[] { "id", "created_by", "created_on", "deleted_by", "deleted_on", "description", "flag", "friendly_code", "is_active", "modified_by", "modified_on", "name" },
                values: new object[,]
                {
                    { new Guid("11155bbf-75ee-434f-b2bc-f1088a184592"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de entregue no ciclo de vida de e-mails.", "#ENTREGUE", "EMAS-11178", true, null, null, "Entregue" },
                    { new Guid("1e8f3a82-407b-020e-fc4b-463f4e2cbd72"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de enviado no ciclo de vida de e-mails.", "#ENVIADO", "EMAS-08303", true, null, null, "Enviado" },
                    { new Guid("9b513552-8e21-ad83-547a-a46ba17bf017"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de falha no ciclo de vida de e-mails.", "#FALHA", "EMAS-23153", true, null, null, "Falha" },
                    { new Guid("d1de51ec-deea-cfc8-7f85-21794fe22deb"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de pendente no ciclo de vida de e-mails.", "#PENDENTE", "EMAS-61294", true, null, null, "Pendente" }
                });

            migrationBuilder.InsertData(
                table: "entity_metadata",
                columns: new[] { "id", "entity_code", "entity_name" },
                values: new object[,]
                {
                    { new Guid("03649403-0d2c-4d2d-1e04-6eb55b3dacb5"), "EC-0394", "ProductVariant" },
                    { new Guid("04d9db3a-e3ae-ff94-1ba9-76a6fb0918e5"), "EC-3ADB", "ProductAttributeValue" },
                    { new Guid("15d70598-9f52-0204-8abc-b4789d8e4752"), "EC-9805", "Address" },
                    { new Guid("17327b49-6b21-226f-cfea-3dafa0bce6ea"), "EC-497B", "OrderStatus" },
                    { new Guid("23e48438-92d2-39cd-79cd-3adbc35a8f0a"), "EC-3884", "Coupon" },
                    { new Guid("30f13273-585d-30eb-e9da-019e0df7966f"), "EC-7332", "Email" },
                    { new Guid("333d8235-1780-503d-3577-bfde3edbb4e0"), "EC-3582", "PaymentGateway" },
                    { new Guid("35280988-10a6-613a-73be-732fb4d44f81"), "EC-8809", "TemplateEmail" },
                    { new Guid("3e8caeec-356d-d371-94f9-4443eb5a7680"), "EC-ECAE", "LogisticProvider" },
                    { new Guid("523bdfdf-1dff-6618-d8df-347a56555097"), "EC-DFDF", "ProductReviewImage" },
                    { new Guid("581ec8f3-dd18-d59c-85f2-dd313864fc05"), "EC-F3C8", "LogisticStatus" },
                    { new Guid("5fa76825-4674-7d65-92ed-00baf4d0d9d3"), "EC-2568", "Invoice" },
                    { new Guid("6704c3de-d7fa-8831-74e1-cd132f6925e7"), "EC-DEC3", "Logistic" },
                    { new Guid("67e286d7-5b2b-928d-2ff1-722a309ebc30"), "EC-D786", "StockTransactionReason" },
                    { new Guid("6a25b676-9367-e87e-3a46-5c2aca6150d9"), "EC-76B6", "Payment" },
                    { new Guid("6b98c5a9-673a-e106-924e-3819eb7a9529"), "EC-A9C5", "User" },
                    { new Guid("6d77516b-106b-9c15-a079-d42e2c2f3ccb"), "EC-6B51", "AccessProfileUser" },
                    { new Guid("6dc0bec9-1c24-501a-a0d7-14e169ad8feb"), "EC-C9BE", "StockTransaction" },
                    { new Guid("6ff680d2-e79d-9087-3a4d-a49417393bfb"), "EC-D280", "InvoiceStatus" },
                    { new Guid("7cc2682f-51a1-1cf9-ed90-d4f814b5ad4c"), "EC-2F68", "ProductVariantAttribute" },
                    { new Guid("7d3d2bce-8fe6-85d1-2c98-809c7fa008cc"), "EC-CE2B", "Stock" },
                    { new Guid("960ca71b-803b-3e9b-93e1-529c93d0a450"), "EC-1BA7", "ProductReview" },
                    { new Guid("9924624f-256a-ddec-3cd8-d0a8646db7be"), "EC-4F62", "PaymentStatus" },
                    { new Guid("9e066f3a-67dc-19e5-9ed9-d8cce70c6389"), "EC-3A6F", "Order" },
                    { new Guid("a6cf937d-e85a-8c0b-61e7-053772e7abb8"), "EC-7D93", "AccessProfile" },
                    { new Guid("aae266b7-e804-daa7-4581-8ac72027e272"), "EC-B766", "ProductImage" },
                    { new Guid("b7b5de7b-6836-2867-4fb2-7c1a8d7830f1"), "EC-7BDE", "ProductAttribute" },
                    { new Guid("c5ea1d0b-a862-878b-aecc-784e43aad221"), "EC-0B1D", "PaymentMethod" },
                    { new Guid("c7286b51-a806-c9ef-a59f-374694992e6a"), "EC-516B", "EmailStatus" },
                    { new Guid("ce7646ed-00da-301d-b650-ee58bd9b57b0"), "EC-ED46", "Customer" },
                    { new Guid("d9015d5a-2708-c8c8-cba8-de003764d6d3"), "EC-5A5D", "Category" },
                    { new Guid("dd69ead4-71a3-eb31-2535-8bdab1ae2d13"), "EC-D4EA", "ProductReviewStatus" },
                    { new Guid("e24edc3c-6398-014d-36e7-9c27f1e62e4b"), "EC-3CDC", "Product" },
                    { new Guid("e85f5a5d-b645-fd3d-326c-9b35e219528a"), "EC-5D5A", "Brand" },
                    { new Guid("ef6d7cf2-43b3-6a51-c0d3-0acd837b75bf"), "EC-F27C", "OrderItem" },
                    { new Guid("efd7372b-187d-2375-afb9-64fa9be1ec16"), "EC-2B37", "LogisticMethod" }
                });

            migrationBuilder.InsertData(
                table: "invoice_status",
                columns: new[] { "id", "created_by", "created_on", "deleted_by", "deleted_on", "description", "flag", "friendly_code", "is_active", "modified_by", "modified_on", "name" },
                values: new object[,]
                {
                    { new Guid("2bbde1ae-95f7-a45a-63ef-39de428f0d2c"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de cancelada no ciclo de vida do processamento de da nota fiscal.", "#CANCELADA", "INVS-45937", true, null, null, "Cancelada" },
                    { new Guid("9b513552-8e21-ad83-547a-a46ba17bf017"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de falha no ciclo de vida do processamento de da nota fiscal.", "#FALHA", "INVS-23153", true, null, null, "Falha" },
                    { new Guid("a394fb9c-d925-30cc-8b7a-71fe9201c9c4"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de emitida no ciclo de vida do processamento de da nota fiscal.", "#EMITIDA", "INVS-61837", true, null, null, "Emitida" },
                    { new Guid("d1de51ec-deea-cfc8-7f85-21794fe22deb"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de pendente no ciclo de vida do processamento de da nota fiscal.", "#PENDENTE", "INVS-61294", true, null, null, "Pendente" }
                });

            migrationBuilder.InsertData(
                table: "logistics_status",
                columns: new[] { "id", "created_by", "created_on", "deleted_by", "deleted_on", "description", "flag", "friendly_code", "is_active", "modified_by", "modified_on", "name" },
                values: new object[,]
                {
                    { new Guid("11155bbf-75ee-434f-b2bc-f1088a184592"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de entregue no ciclo de vida da entrega logística.", "#ENTREGUE", "LGCS-11178", true, null, null, "Entregue" },
                    { new Guid("7367baf2-fe58-15d9-2158-ccfadbee39a7"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de devolvido no ciclo de vida da entrega logística.", "#DEVOLVIDO", "LGCS-26358", true, null, null, "Devolvido" },
                    { new Guid("b1362175-83a0-405c-7db1-e9bef65d8924"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de extraviado no ciclo de vida da entrega logística.", "#EXTRAVIAD", "LGCS-73470", true, null, null, "Extraviado" },
                    { new Guid("c3009dc5-b854-e093-3292-34b326f35cd3"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de saiu para entrega no ciclo de vida da entrega logística.", "#SAIPARENT", "LGCS-77054", true, null, null, "Saiu para Entrega" },
                    { new Guid("c9e32627-8e06-aace-3a84-1700042fba93"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de em transito no ciclo de vida da entrega logística.", "#EMTRAN", "LGCS-98716", true, null, null, "Em Transito" },
                    { new Guid("e68916a3-90a5-61a1-7953-3dac2c561198"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de postado no ciclo de vida da entrega logística.", "#POSTADO", "LGCS-32705", true, null, null, "Postado" },
                    { new Guid("fefe94a3-b087-3ea7-c163-223787ea9023"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de aguardando coleta no ciclo de vida da entrega logística.", "#AGUACOLE", "LGCS-38445", true, null, null, "Aguardando Coleta" }
                });

            migrationBuilder.InsertData(
                table: "order_status",
                columns: new[] { "id", "created_by", "created_on", "deleted_by", "deleted_on", "description", "flag", "friendly_code", "is_active", "modified_by", "modified_on", "name" },
                values: new object[,]
                {
                    { new Guid("2249a7e6-22cd-68a9-8f90-91d1490b4b14"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de novo no ciclo de vida global do pedido.", "#NOVO", "ORDS-07345", true, null, null, "Novo" },
                    { new Guid("23ffbd54-6104-4875-7e9e-c40879c9b585"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de separacao em estoque no ciclo de vida global do pedido.", "#SEPEMEST", "ORDS-49554", true, null, null, "Separacao em Estoque" },
                    { new Guid("3a08a534-2ea0-59a3-72d1-ba32ab20fd6f"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de concluido no ciclo de vida global do pedido.", "#CONCLUIDO", "ORDS-25880", true, null, null, "Concluido" },
                    { new Guid("56c703a2-90fa-be3b-dd61-9603ac4de531"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de aguardando envio no ciclo de vida global do pedido.", "#AGUAENVI", "ORDS-23960", true, null, null, "Aguardando Envio" },
                    { new Guid("a1072f20-40f6-4b45-d532-e4e1e6a75715"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de processando no ciclo de vida global do pedido.", "#PROCESSAN", "ORDS-27716", true, null, null, "Processando" },
                    { new Guid("c4f5b004-38f2-a2a5-ab17-24a790786e54"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de cancelado no ciclo de vida global do pedido.", "#CANCELADO", "ORDS-46562", true, null, null, "Cancelado" }
                });

            migrationBuilder.InsertData(
                table: "payment_status",
                columns: new[] { "id", "created_by", "created_on", "deleted_by", "deleted_on", "description", "flag", "friendly_code", "is_active", "modified_by", "modified_on", "name" },
                values: new object[,]
                {
                    { new Guid("0f85dd3b-381e-be00-a389-5708e211781b"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de recusado no ciclo de vida do fluxo financeiro.", "#RECUSADO", "PAYS-91350", true, null, null, "Recusado" },
                    { new Guid("7f978d45-33bd-7268-1dae-b700fca3ad6c"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de estornado no ciclo de vida do fluxo financeiro.", "#ESTORNADO", "PAYS-91179", true, null, null, "Estornado" },
                    { new Guid("c4f5b004-38f2-a2a5-ab17-24a790786e54"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de cancelado no ciclo de vida do fluxo financeiro.", "#CANCELADO", "PAYS-46562", true, null, null, "Cancelado" },
                    { new Guid("c638a815-77fc-31a9-5ce9-cf84d03b511e"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de aprovado no ciclo de vida do fluxo financeiro.", "#APROVADO", "PAYS-18682", true, null, null, "Aprovado" },
                    { new Guid("d3a9430c-152d-3c97-aa07-50ec2bcdca8c"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de em analise no ciclo de vida do fluxo financeiro.", "#EMANAL", "PAYS-27915", true, null, null, "Em Analise" },
                    { new Guid("e2beede6-cb9c-978a-27fc-b767459daa54"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de aguardando pagamento no ciclo de vida do fluxo financeiro.", "#AGUAPAGA", "PAYS-07066", true, null, null, "Aguardando Pagamento" }
                });

            migrationBuilder.InsertData(
                table: "product_review_status",
                columns: new[] { "id", "created_by", "created_on", "deleted_by", "deleted_on", "description", "flag", "friendly_code", "is_active", "modified_by", "modified_on", "name" },
                values: new object[,]
                {
                    { new Guid("c4bd1620-4586-b842-65d3-bc7bca54ac15"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de arquivado no ciclo de vida do processamento de reviews.", "#ARQUIVADO", "PDRS-22964", true, null, null, "Arquivado" },
                    { new Guid("c4f31136-2875-0f82-70b4-f94359468391"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de pendente de aprovação no ciclo de vida do processamento de reviews.", "#PENDEAPR", "PDRS-47367", true, null, null, "Pendente de Aprovação" },
                    { new Guid("c638a815-77fc-31a9-5ce9-cf84d03b511e"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de aprovado no ciclo de vida do processamento de reviews.", "#APROVADO", "PDRS-18682", true, null, null, "Aprovado" },
                    { new Guid("cd4f874a-61b1-a6ea-52ae-e4fb0f47d4c1"), new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc), null, null, "Define o estado de rejeitado no ciclo de vida do processamento de reviews.", "#REJEITADO", "PDRS-45957", true, null, null, "Rejeitado" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_access_profile_name",
                table: "access_profile",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_accessprofile_friendly_code",
                table: "access_profile",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_accessprofile_not_deleted",
                table: "access_profile",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_access_profile_user_profile_id",
                table: "access_profile_user",
                column: "access_profile_id");

            migrationBuilder.CreateIndex(
                name: "ix_access_profile_user_unique_combination",
                table: "access_profile_user",
                columns: new[] { "user_id", "access_profile_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_accessprofileuser_friendly_code",
                table: "access_profile_user",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_accessprofileuser_not_deleted",
                table: "access_profile_user",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_address_city",
                table: "address",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "ix_address_customer_id",
                table: "address",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_address_customer_type",
                table: "address",
                columns: new[] { "customer_id", "address_type" });

            migrationBuilder.CreateIndex(
                name: "ix_address_friendly_code",
                table: "address",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_address_not_deleted",
                table: "address",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_address_postal_code",
                table: "address",
                column: "postal_code");

            migrationBuilder.CreateIndex(
                name: "ix_address_state",
                table: "address",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "ix_brand_cnpj",
                table: "brand",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_brand_email_address",
                table: "brand",
                column: "email_address",
                unique: true,
                filter: "email_address IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_brand_friendly_code",
                table: "brand",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_brand_mobile_phone",
                table: "brand",
                column: "mobile_phone",
                unique: true,
                filter: "mobile_phone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_brand_name",
                table: "brand",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_brand_not_deleted",
                table: "brand",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_brand_telephone",
                table: "brand",
                column: "telephone",
                unique: true,
                filter: "telephone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_brand_url_key",
                table: "brand",
                column: "url_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cart_item_product_variant_id",
                table: "cart_item",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_category_friendly_code",
                table: "category",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_category_not_deleted",
                table: "category",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "IX_category_ParentCategoryId",
                table: "category",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "ix_category_url_key",
                table: "category",
                column: "url_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_coupon_category_id",
                table: "coupon",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_coupon_code",
                table: "coupon",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_coupon_friendly_code",
                table: "coupon",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_coupon_not_deleted",
                table: "coupon",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_customer_friendly_code",
                table: "customer",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_customer_not_deleted",
                table: "customer",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_customer_trade_name",
                table: "customer",
                column: "trade_name");

            migrationBuilder.CreateIndex(
                name: "ix_customer_user_id",
                table: "customer",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_national_id",
                table: "customer",
                column: "national_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_email_address",
                table: "email",
                column: "email_address");

            migrationBuilder.CreateIndex(
                name: "IX_email_email_status_id",
                table: "email",
                column: "email_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_email_metadata_reference",
                table: "email",
                columns: new[] { "entity_metadata_id", "reference_id" });

            migrationBuilder.CreateIndex(
                name: "IX_email_template_email_id",
                table: "email",
                column: "template_email_id");

            migrationBuilder.CreateIndex(
                name: "ix_emailstatus_flag",
                table: "email_status",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_emailstatus_friendly_code",
                table: "email_status",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_emailstatus_name",
                table: "email_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_emailstatus_not_deleted",
                table: "email_status",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_entity_metadata_code",
                table: "entity_metadata",
                column: "entity_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_entity_metadata_name",
                table: "entity_metadata",
                column: "entity_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoice_external_id",
                table: "invoice",
                column: "external_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoice_friendly_code",
                table: "invoice",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_InvoiceStatusId",
                table: "invoice",
                column: "InvoiceStatusId");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_not_deleted",
                table: "invoice",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_invoice_number_series",
                table: "invoice",
                columns: new[] { "number", "series" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invoice_order_id",
                table: "invoice",
                column: "order_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoicestatus_flag",
                table: "invoice_status",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoicestatus_friendly_code",
                table: "invoice_status",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoicestatus_name",
                table: "invoice_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_invoicestatus_not_deleted",
                table: "invoice_status",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_logistic_friendly_code",
                table: "logistics",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logistic_not_deleted",
                table: "logistics",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "IX_logistics_logistics_method_id",
                table: "logistics",
                column: "logistics_method_id");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_order_volume",
                table: "logistics",
                columns: new[] { "order_id", "volume_number" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logistics_status_id",
                table: "logistics",
                column: "logistics_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_tracking_code",
                table: "logistics",
                column: "tracking_code");

            migrationBuilder.CreateIndex(
                name: "ix_logisticmethod_friendly_code",
                table: "logistics_method",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logisticmethod_not_deleted",
                table: "logistics_method",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_method_code",
                table: "logistics_method",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logistics_method_Name",
                table: "logistics_method",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_method_provider_id",
                table: "logistics_method",
                column: "logistics_provider_id");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_method_provider_id_name",
                table: "logistics_method",
                columns: new[] { "logistics_provider_id", "name" });

            migrationBuilder.CreateIndex(
                name: "ix_logisticprovider_friendly_code",
                table: "logistics_provider",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logisticprovider_not_deleted",
                table: "logistics_provider",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_provider_cnpj",
                table: "logistics_provider",
                column: "cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logistics_provider_code",
                table: "logistics_provider",
                column: "code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logistics_provider_email_address",
                table: "logistics_provider",
                column: "email_address",
                unique: true,
                filter: "email_address IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_provider_mobile_phone",
                table: "logistics_provider",
                column: "mobile_phone",
                unique: true,
                filter: "mobile_phone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_provider_name",
                table: "logistics_provider",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_logistics_provider_telephone",
                table: "logistics_provider",
                column: "telephone",
                unique: true,
                filter: "telephone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_logisticstatus_flag",
                table: "logistics_status",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logisticstatus_friendly_code",
                table: "logistics_status",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logisticstatus_name",
                table: "logistics_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_logisticstatus_not_deleted",
                table: "logistics_status",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_order_city",
                table: "order",
                column: "city");

            migrationBuilder.CreateIndex(
                name: "IX_order_coupon_id",
                table: "order",
                column: "coupon_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_friendly_code",
                table: "order",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_not_deleted",
                table: "order",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "IX_order_order_status_id",
                table: "order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_postal_code",
                table: "order",
                column: "postal_code");

            migrationBuilder.CreateIndex(
                name: "ix_order_state",
                table: "order",
                column: "state");

            migrationBuilder.CreateIndex(
                name: "ix_order_item_order_product_unique",
                table: "order_item",
                columns: new[] { "order_id", "product_variant_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_order_item_variant_id",
                table: "order_item",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_orderitem_friendly_code",
                table: "order_item",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderitem_not_deleted",
                table: "order_item",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_orderstatus_flag",
                table: "order_status",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderstatus_friendly_code",
                table: "order_status",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderstatus_name",
                table: "order_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_orderstatus_not_deleted",
                table: "order_status",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_payment_external_transaction",
                table: "payment",
                column: "external_transaction_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_friendly_code",
                table: "payment",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payment_gateway_id",
                table: "payment",
                column: "payment_gateway_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_id",
                table: "payment",
                column: "payment_method_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_not_deleted",
                table: "payment",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_payment_order_id",
                table: "payment",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_payment_status_id",
                table: "payment",
                column: "payment_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_name_unique",
                table: "payment_gateway",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payment_gateway_email_address",
                table: "payment_gateway",
                column: "email_address",
                unique: true,
                filter: "email_address IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_payment_gateway_environment_key_unique",
                table: "payment_gateway",
                column: "environment_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payment_gateway_flag_unique",
                table: "payment_gateway",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payment_gateway_mobile_phone",
                table: "payment_gateway",
                column: "mobile_phone",
                unique: true,
                filter: "mobile_phone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_payment_gateway_telephone",
                table: "payment_gateway",
                column: "telephone",
                unique: true,
                filter: "telephone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_paymentgateway_friendly_code",
                table: "payment_gateway",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paymentgateway_not_deleted",
                table: "payment_gateway",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_gateway_flag_unique",
                table: "payment_method",
                column: "gateway_flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_gateway_name_unique",
                table: "payment_method",
                columns: new[] { "payment_gateway_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_payment_method_name",
                table: "payment_method",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_paymentmethod_friendly_code",
                table: "payment_method",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paymentmethod_not_deleted",
                table: "payment_method",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_paymentstatus_flag",
                table: "payment_status",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paymentstatus_friendly_code",
                table: "payment_status",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paymentstatus_name",
                table: "payment_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_paymentstatus_not_deleted",
                table: "payment_status",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_Brand_id",
                table: "product",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_friendly_code",
                table: "product",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_name",
                table: "product",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_product_not_deleted",
                table: "product",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_product_url_key_unique",
                table: "product",
                column: "url_key",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_attribute_name_unique",
                table: "product_attribute",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productattribute_friendly_code",
                table: "product_attribute",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productattribute_not_deleted",
                table: "product_attribute",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_product_attribute_value_Name",
                table: "product_attribute_value",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "ix_product_attribute_value_unique",
                table: "product_attribute_value",
                columns: new[] { "product_attribute_id", "name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productattributevalue_friendly_code",
                table: "product_attribute_value",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productattributevalue_not_deleted",
                table: "product_attribute_value",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_category_id",
                table: "product_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_category_unique_main",
                table: "product_category",
                column: "product_id",
                unique: true,
                filter: "is_main = true");

            migrationBuilder.CreateIndex(
                name: "ix_product_image_file_name",
                table: "product_image",
                column: "file_name");

            migrationBuilder.CreateIndex(
                name: "ix_product_image_product_id",
                table: "product_image",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_image_variant_id",
                table: "product_image",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_productimage_friendly_code",
                table: "product_image",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productimage_not_deleted",
                table: "product_image",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_productreview_friendly_code",
                table: "product_review",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productreview_not_deleted",
                table: "product_review",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_review_customer_id",
                table: "product_review",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "ix_review_order_id",
                table: "product_review",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_review_product_id",
                table: "product_review",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_review_product_review_status_id",
                table: "product_review",
                column: "product_review_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_productreviewimage_friendly_code",
                table: "product_review_image",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productreviewimage_not_deleted",
                table: "product_review_image",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_review_image_file_name",
                table: "product_review_image",
                column: "file_name");

            migrationBuilder.CreateIndex(
                name: "ix_review_image_review_id",
                table: "product_review_image",
                column: "product_review_id");

            migrationBuilder.CreateIndex(
                name: "ix_productreviewstatus_flag",
                table: "product_review_status",
                column: "flag",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productreviewstatus_friendly_code",
                table: "product_review_status",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productreviewstatus_name",
                table: "product_review_status",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productreviewstatus_not_deleted",
                table: "product_review_status",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_ean",
                table: "product_variant",
                column: "ean");

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_product_id",
                table: "product_variant",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_sku_unique",
                table: "product_variant",
                column: "sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productvariant_friendly_code",
                table: "product_variant",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productvariant_not_deleted",
                table: "product_variant",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_attribute_unique",
                table: "product_variant_attribute",
                columns: new[] { "product_variant_id", "product_attribute_value_id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_product_variant_attribute_value_id",
                table: "product_variant_attribute",
                column: "product_attribute_value_id");

            migrationBuilder.CreateIndex(
                name: "ix_productvariantattribute_friendly_code",
                table: "product_variant_attribute",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_productvariantattribute_not_deleted",
                table: "product_variant_attribute",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_stock_friendly_code",
                table: "stock",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stock_not_deleted",
                table: "stock",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_stock_product_variant_id_unique",
                table: "stock",
                column: "product_variant_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stock_transaction_order_id",
                table: "stock_transaction",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_transaction_Reason_id",
                table: "stock_transaction",
                column: "stock_transaction_reason_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_transaction_type",
                table: "stock_transaction",
                column: "stock_transaction_type");

            migrationBuilder.CreateIndex(
                name: "ix_stock_transaction_variant_id",
                table: "stock_transaction",
                column: "product_variant_id");

            migrationBuilder.CreateIndex(
                name: "ix_stocktransaction_friendly_code",
                table: "stock_transaction",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stocktransaction_not_deleted",
                table: "stock_transaction",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_User_id",
                table: "stock_transaction",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_stock_transaction_reason_name",
                table: "stock_transaction_reason",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stocktransactionreason_friendly_code",
                table: "stock_transaction_reason",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_stocktransactionreason_not_deleted",
                table: "stock_transaction_reason",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_template_email_name",
                table: "template_email",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_templateemail_friendly_code",
                table: "template_email",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_templateemail_not_deleted",
                table: "template_email",
                column: "is_deleted",
                filter: "is_deleted = false");

            migrationBuilder.CreateIndex(
                name: "ix_user_email_address",
                table: "user",
                column: "email_address",
                unique: true,
                filter: "email_address IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_first_name",
                table: "user",
                column: "first_name");

            migrationBuilder.CreateIndex(
                name: "ix_user_friendly_code",
                table: "user",
                column: "friendly_code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_user_mobile_phone",
                table: "user",
                column: "mobile_phone",
                unique: true,
                filter: "mobile_phone IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "ix_user_not_deleted",
                table: "user",
                column: "is_deleted",
                filter: "is_deleted = false");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "access_profile_user");

            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "cart_item");

            migrationBuilder.DropTable(
                name: "email");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "logistics");

            migrationBuilder.DropTable(
                name: "order_item");

            migrationBuilder.DropTable(
                name: "payment");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.DropTable(
                name: "product_image");

            migrationBuilder.DropTable(
                name: "product_review_image");

            migrationBuilder.DropTable(
                name: "product_variant_attribute");

            migrationBuilder.DropTable(
                name: "stock");

            migrationBuilder.DropTable(
                name: "stock_transaction");

            migrationBuilder.DropTable(
                name: "access_profile");

            migrationBuilder.DropTable(
                name: "email_status");

            migrationBuilder.DropTable(
                name: "entity_metadata");

            migrationBuilder.DropTable(
                name: "template_email");

            migrationBuilder.DropTable(
                name: "invoice_status");

            migrationBuilder.DropTable(
                name: "logistics_method");

            migrationBuilder.DropTable(
                name: "logistics_status");

            migrationBuilder.DropTable(
                name: "payment_method");

            migrationBuilder.DropTable(
                name: "payment_status");

            migrationBuilder.DropTable(
                name: "product_review");

            migrationBuilder.DropTable(
                name: "product_attribute_value");

            migrationBuilder.DropTable(
                name: "product_variant");

            migrationBuilder.DropTable(
                name: "stock_transaction_reason");

            migrationBuilder.DropTable(
                name: "logistics_provider");

            migrationBuilder.DropTable(
                name: "payment_gateway");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product_review_status");

            migrationBuilder.DropTable(
                name: "product_attribute");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "coupon");

            migrationBuilder.DropTable(
                name: "customer");

            migrationBuilder.DropTable(
                name: "order_status");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
