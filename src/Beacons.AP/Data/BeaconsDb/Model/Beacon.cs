using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Beacons.AP.Data.BeaconsDb.Model
{
    public class Beacon
    {   
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [BsonId]
        [JsonIgnore]
        public ObjectId Id { get; set; }

        /// <summary>
        /// Gets or sets the beacon identifier.
        /// </summary>
        /// <value>
        /// The beacon identifier.
        /// </value>
        public string BeaconId { get; set; }

        /// <summary>
        /// Gets or sets the beacon title.
        /// </summary>
        /// <value>
        /// The beacon title.
        /// </value>
        public string Title { get; set; }
    }
}
