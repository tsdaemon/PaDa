namespace PaDa.Task1
{
    public class PrefixScanSequential : PrefixScanBase
    {
        public override int[] Scan(int[] input)
        {
            var result = new int[input.Length + 1];
            for (var i = 0; i < input.Length; i++)
            {
                result[i + 1] = result[i] + input[i];
            }
            return result;
        }
    }
}
