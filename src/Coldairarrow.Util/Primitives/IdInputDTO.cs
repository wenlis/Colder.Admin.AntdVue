namespace Coldairarrow.Util
{
    public class IdInputDTO : IdInputDTO<string>
    {
    }

    public class IdInputDTO<T>
    {
        /// <summary>
        /// id
        /// </summary>
        public T id { get; set; }
    }
}
