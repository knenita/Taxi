namespace Taxi.Common.Models
{
    public class Response
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }//si no pudo se devuekve mesn
        public object Result { get; set; }//si pudo devuelve resultado json
    }
}