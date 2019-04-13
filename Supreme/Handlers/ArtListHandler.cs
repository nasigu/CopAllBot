using Supreme.Model;
using System.Collections.Generic;

namespace Supreme.Handlers

{
    public class ArtListHandler
    {
        public ArtListHandler()
        {
            ArtLists = new List<ArtList>();
        }

        public List<ArtList> ArtLists { get; private set; }

        public void Add(ArtList item)
        {
            ArtLists.Add(item);
        }
    }
}
