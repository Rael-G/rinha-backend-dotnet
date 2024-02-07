using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rinha.Api.Migrations
{
    /// <inheritdoc />
    public partial class Gin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE EXTENSION IF NOT EXISTS pg_trgm;");

            migrationBuilder.Sql("CREATE INDEX idx_pessoa_searchable_gist ON \"Pessoas\" USING gist (\"Searchable\" gist_trgm_ops);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP INDEX IF EXISTS idx_pessoa_searchable_gist;");

            migrationBuilder.Sql("DROP EXTENSION IF EXISTS pg_trgm;");

        }
    }
}
