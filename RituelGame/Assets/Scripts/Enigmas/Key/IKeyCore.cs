namespace Enigmas.Key
{
    public interface IKeyCore
    {
        public KeyEnigmaData _KeyEnigmaData { get; }
        
        public void SetEnigmaData(KeyEnigmaData enigmaData);
    }
}