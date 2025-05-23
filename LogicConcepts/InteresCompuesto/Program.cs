using System;

internal class Program
{
    private static void Main()
    {
        // Parámetros
        decimal tasaInteresAnual = 0.08m;  // Tasa de interés anual del 8%
        decimal inflacionAnual = 0.05m;    // Inflación del 5%
        int años = 10;                    // Periodo de tiempo en años
        int mesesPorAño = 12;             // Número de meses por año
        decimal salarioMinimoMensual = 1300000m;  // Salario mínimo actual (aproximadamente)
        decimal ahorroPorSmlv = 1.5m;      // Ahorro mensual como 1.5 SMLV

        decimal ahorroMensual;            // Ahorro mensual en pesos, se actualizará cada año
        decimal ahorroTotal = 0m;         // Ahorro acumulado

        // Calcular tasa de interés mensual
        decimal tasaInteresMensual = tasaInteresAnual / mesesPorAño;

        // Calcular número total de meses
        int totalMeses = años * mesesPorAño;

        // Simulación año por año para ajustar el ahorro mensual según la inflación
        for (int año = 1; año <= años; año++)
        {
            // Ajustamos el salario mínimo por inflación cada año
            salarioMinimoMensual *= (1 + inflacionAnual);

            // El ahorro mensual es 1.5 veces el salario mínimo mensual ajustado por inflación
            ahorroMensual = ahorroPorSmlv * salarioMinimoMensual;

            // Fórmula de interés compuesto para el ahorro mensual de ese año
            ahorroTotal += ahorroMensual * ((decimal)Math.Pow((double)(1 + tasaInteresMensual), mesesPorAño) - 1) / tasaInteresMensual;
        }

        // Ajustar por inflación (ajuste final por inflación de 10 años)
        decimal valorAjustadoFinal = ahorroTotal / (decimal)Math.Pow((double)(1 + inflacionAnual), años);

        // Calcular cuántos salarios mínimos (SMLV) equivalen al ahorro final
        decimal smlvEquivalente = valorAjustadoFinal / salarioMinimoMensual;

        // Mostrar resultados
        Console.WriteLine($"Ahorro total ajustado por inflación: {valorAjustadoFinal:C2} pesos");
        Console.WriteLine($"Equivalente en salarios mínimos (SMLV) ajustado: {smlvEquivalente:F2} SMLV");
    }
}