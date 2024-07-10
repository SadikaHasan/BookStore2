namespace BookStore.BL.Background
{
    public class ProducerConf
    {
        
        public string BootstrapServers { get; set; }
        public object SecurityProtocol { get; set; }
        public string SaslUsername { get; set; }
        public string SaslPassword { get; set; }
        public object SaslMechanism { get; set; }

    }
}