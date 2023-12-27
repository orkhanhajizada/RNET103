namespace SealedClass.Models;

public class Box <T> //T yerine ne olsa yazila biler sadece Type`dan qisaltma kimi adeten T  yazilir
{
    private T _content { get; set; }

    public void Setbox(T content)
    {
        _content = content;
    }

    public T GetContent()
    {
        return _content;
    }

    public T Set
    {
        set => _content = value;
    }

    public T Get
    {
        get => _content;
    }
}