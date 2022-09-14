using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentAccess.Models
{
    public class CosmosSettings
    {
        /// <summary>
        /// Gets or sets the endpoint.
        /// </summary>
        public string EndPoint { get; set; }

        /// <summary>
        /// Gets or sets the access key.
        /// </summary>
        public string AccessKey { get; set; }

        public string Database { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether startup should check for migrations.
        /// </summary>
        public bool EnableMigration { get; set; }
    }
}
