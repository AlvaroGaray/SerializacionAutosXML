
using System.Text.RegularExpressions;
using System.Xml.Serialization;

Console.WriteLine("Serializacion XML en c#\r");
Console.WriteLine("--------------------------------");
XmlSerializer formatter = new XmlSerializer(typeof(RegistroVehiculos));
Stream stream = null;
RegistroVehiculos registro = null;
int año;
string ValorAño = "";
string chasis = "";
string marca = "";
string modelo = "";
decimal precio = 0.0M;
string ValorPrecio = "";
//Pidale al usuario que elija una opcion 

Console.WriteLine("Elija una opcion de las siguiente lista :");
Console.WriteLine("\ts-Crear y serializar un registro ");
Console.WriteLine("\td-Deserializar registro ");
Console.WriteLine("¿Sus opciones?");


string op = Console.ReadLine();
switch (op)
{
    case "s":
        //se crea el stream

        stream = new FileStream("RegistroVehiculos.xml", FileMode.OpenOrCreate, FileAccess.Write);
        //Creamos el obejto de registro 

        //Pida al usuario que ingrese el año del vehiculo

        Console.Write("Escriba el año del vehiculo y luego presiones enter: ");
        ValorAño = Console.ReadLine();

        while (!int.TryParse(ValorAño, out año))
        {
            Console.Write("Esta entrada no es válida. introduzca un valor entero: ");
            ValorAño = Console.ReadLine();
        }
        //Pida al usuario el chasis del vehiculo
        Console.WriteLine("Escriba el chasis y luego presione enter: ");
        chasis = Console.ReadLine();

        //Pida al usuario la marca
        Console.Write("Escriba la marca y luego presione enter: ");
        marca = Console.ReadLine();

        //Pida al usuario el modelo
        Console.Write("Escriba el modelo y luego presione enter: ");
        modelo = Console.ReadLine();

        //Pida al usuario el precio del vehiculo
        Console.Write("Escriba el precio y luego presione enter: ");
        ValorPrecio = Console.ReadLine();

        while (!decimal.TryParse(ValorPrecio, out precio))
        {
            Console.WriteLine("Esta entrada no es válida. introduzca un valor decimal: ");
            ValorPrecio = Console.ReadLine();
        }

        registro = new RegistroVehiculos(año, chasis, marca, modelo,precio);
        Console.WriteLine("Registro a serializar ");
        Console.WriteLine(registro.ToString());

        //Empezamos la serialización
        Console.WriteLine("-------------------------------Serializamos----------------------------------------------");

        //Serializamos 
        formatter.Serialize(stream, registro);
        //Cerramos el stream
        stream.Close();
        break;

    case "d":

        //Empezamos la deserialización
        Console.WriteLine("-------------------------------Deserializamos----------------------------------------------");

        //Abrimos stream 
        stream = new FileStream("RegistroVehiculos.xml", FileMode.Open, FileAccess.Read);
        //Deserilizamos 
        registro = (RegistroVehiculos)formatter.Deserialize(stream);

        //Cerramos stream 
        stream.Close();
        //usamos el objeto 
        Console.WriteLine("El objeto deserializado es: ");
        Console.WriteLine(registro.ToString());

        break;

    default:
        Console.WriteLine("!Opcion invalida¡");
        break;


}

[Serializable]
public class RegistroVehiculos
{
    private int año;
    private string Chasis;
    private string Marca;
    private string Modelo;
    private decimal Precio;

    public RegistroVehiculos() : this(0, "", "","", 0.0M)
    {

    }

    public RegistroVehiculos(int ValorAño, string ValorChasis, string ValorMarca, string ValorModelo, decimal ValorPrecio)
    {
        Año = ValorAño;
        Chasis1 = ValorChasis;
        Marca1 = ValorMarca;
        Modelo1 = ValorModelo;
        Precio1 = ValorPrecio;
    }

    public int Año { get => año; set => año = value; }
    public string Chasis1 { get => Chasis; set => Chasis = value; }
    public string Modelo1 { get => Modelo; set => Modelo = value; }
    public string Marca1 { get => Marca; set => Marca = value; }
    public decimal Precio1 { get => Precio; set => Precio = value; }

    public override string ToString()
    {
        return "Año: " + año + "\n" +
            "Chasis: " + Chasis + "\n" +
           "Marca: " + Marca + "\n" +
           "Modelo: " + Modelo + "\n"+
           "Precio: " + Precio + "\n";
    }

}


