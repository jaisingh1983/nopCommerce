using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Book;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.Media;
using Nop.Data.Extensions;

namespace Nop.Data.Mapping.Builders.Book
{
    public partial class BookMapBuilder : NopEntityBuilder<Books>
    {
        #region Methods

        /// <summary>
        /// Apply entity configuration
        /// </summary>
        /// <param name="table">Create table expression builder</param>
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(Books.Id)).AsInt32().PrimaryKey()
                .WithColumn(nameof(Books.Name)).AsString(400).NotNullable()
                .WithColumn(nameof(Books.CreatedOn)).AsDateTime();
            
        }

        #endregion
    }
}
