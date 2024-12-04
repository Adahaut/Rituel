namespace Enigmas.Key
{
    public interface IKeyCore
    {
        public KeyEnigmaData _keyEnigmaData { get; }
        
        public void SetEnigmaData(KeyEnigmaData enigmaData);
    }
}