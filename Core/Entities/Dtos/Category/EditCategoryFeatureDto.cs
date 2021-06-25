using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Dtos.Category
{
    public class EditCategoryFeatureDto
    {
        /// <summary>
        /// categoryfield idsi
        /// </summary>
        public long? Id { get; set; }
        /// <summary>
        /// fieldin idsi
        /// </summary>
        public long? FeatureId { get; set; }
        public long? CategoryId { get; set; }
    }
}
