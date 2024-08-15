namespace Deol.ASTM.LabOnline
{
    public class ASTMList<T> : List<T>
    {
        public void Add(IEnumerable<T> collection) => AddRange(collection);
    }
}
