using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    [Serializable]
    public class Smartphone : InteractionIntefaceMobile
    {
        [JsonProperty]
        private string audioTypeSupportLinks;
        
        [JsonProperty]
        private string connectionConnector;

        public Smartphone(string audioTypeSupportLinks, string connectionConnector, bool frontLightning, ProcessorInfo processor, bool NFC, string bluetooth) : base(frontLightning, processor, NFC, bluetooth)
        {                 
            this.audioTypeSupportLinks = audioTypeSupportLinks;
            this.connectionConnector = connectionConnector;
        }

        public Smartphone()
        {

        }

        public string GetAudioTypeSupportLinks()
        {
            return audioTypeSupportLinks;
        }

        public void SetAudioTypeSupportLinks(string audioTypeSupportLinks)
        {
            this.audioTypeSupportLinks = audioTypeSupportLinks;
        }

        public string GetConnectionConnector()
        {
            return connectionConnector;
        }

        public void SetConnectionConnector(string connectionConnector)
        {
            this.connectionConnector = connectionConnector;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append(base.ToString());
            strBuilder.Append("Audio type support links: ");
            strBuilder.Append(audioTypeSupportLinks);
            strBuilder.Append(";\n");
            strBuilder.Append("Connection connector: ");
            strBuilder.Append(connectionConnector);
            strBuilder.Append(";\n");


            return strBuilder.ToString();
        }
    }
}
