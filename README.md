# Enigma
.NET C# Enigma machine emulator

Read article about Enigma in my blog:
https://dev.koshovyi.com/2020/12/14/emulyator-shifrovalnoj-mashiny-enigma-c-net/

### How to use:

```
static void Main(string[] args)
{
    Console.WriteLine("Enigma machine emulator:");
            
    string data = "The quick brown fox jumps over the lazy dog";
    Enigma e = new Enigma();

    //Plugboard
    e.Plugboard.Add('X', 'D');
    e.Plugboard.Add('A', 'V');
            
    //Rotors
    e.Rotors.Add(RotorType.Rotor_I, 'A');
    e.Rotors.Add(RotorType.Rotor_II, 'B');
    e.Rotors.Add(RotorType.Rotor_III, 'C');

    //Reflector
    e.Rotors.SetReflector(ReflectorType.UWK_B);

    string result = e.Encrypt(data);

    Console.WriteLine("Input: " + data);
    Console.WriteLine("Output: " + result);

    Console.WriteLine();
    Console.Read();
}
```

Console output:

```
Enigma machine emulator:
Input: The quick brown fox jumps over the lazy dog
Output: CAK OAZIJ MOGPG ZTP ATOWC FIAQ EJM ZCKT SGO
```