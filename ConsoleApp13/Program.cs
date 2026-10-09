// Muestra el título del sistema en consola
Console.WriteLine("SISTEMA DE CONTROL DE POSICIÓN DE SERVOMOTOR");
Console.WriteLine();

// Crea el objeto servo1 de la clase Servomotor
Servomotor servo1 = new Servomotor();

// Ciclo while infinito para asegurar que los datos ingresados sean válidos
while (true)
{
    // Captura la posición en la que se encuentra el servomotor actualmente
    Console.Write("Ingrese la posición actual (0 - 180 °): ");
    servo1.PosicionActual = Convert.ToDouble(Console.ReadLine());

    // Captura la posición a la que se desea mover el servomotor
    Console.Write("Ingrese la posición objetivo (0 - 180 °): ");
    servo1.PosicionObjetivo = Convert.ToDouble(Console.ReadLine());

    // Valida que ambos valores se encuentren dentro del rango permitido de 0 a 180 grados
    if (servo1.PosicionActual >= 0 && servo1.PosicionActual <= 180 &&
        servo1.PosicionObjetivo >= 0 && servo1.PosicionObjetivo <= 180)
    {
        break; // Rompe el ciclo si los datos son correctos
    }
    // Muestra un mensaje de error si están fuera de rango y vuelve a pedir los datos
    Console.WriteLine("Error: Los valores deben estar entre 0 y 180 °. Intente nuevamente.\n");
}

// Muestra en pantalla el desplazamiento absoluto calculado y la dirección del movimiento
Console.WriteLine();
Console.WriteLine($"Desplazamiento absoluto: {servo1.CalcularDesplazamiento():F2} °");
Console.WriteLine($"Movimiento: {servo1.ObtenerDireccionMovimiento()}");

// Definición de la clase Servomotor
class Servomotor
{
    // Propiedad para la posición actual
    public double PosicionActual { get; set; }
    // Propiedad para la posición objetivo
    public double PosicionObjetivo { get; set; }

    // Método que calcula el desplazamiento absoluto (evita valores negativos)
    public double CalcularDesplazamiento()
    {
        double diferencia = PosicionObjetivo - PosicionActual;
        if (diferencia < 0) return diferencia * -1; // Convierte a positivo si es menor
        return diferencia;
    }

    // Método que determina si el movimiento es ascendente, descendente o nulo
    public string ObtenerDireccionMovimiento()
    {
        if (PosicionObjetivo > PosicionActual)
            return "Movimiento hacia una posición mayor";
        else if (PosicionObjetivo < PosicionActual)
            return "Movimiento hacia una posición menor";
        else
            return "No hay movimiento";
    }
}