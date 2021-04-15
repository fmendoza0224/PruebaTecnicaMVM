namespace ComunicacionesAlpha.Transversal
{
    public static class StringExtension
    {
        public static string AdicionarCero(this string valor)
        {
            return valor.Length == 1 ? $"0{valor}" : valor;
        }
    }
}
