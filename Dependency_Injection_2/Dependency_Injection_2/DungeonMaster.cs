using Dungeon_And_Dragons_ClassLibrary;
using Pen_And_Paper_ClassLibrary;

namespace ConsoleUI
{
    public class DungeonMaster : IDungeonMaster, IDungeonMaster2
    {
        
        private readonly IDungeonMaster2 _master2;
        private readonly IDungeon _dungeon;
        private readonly IPaper _paper;
        private readonly IPen _pen;

        public DungeonMaster( 
            IDungeonMaster2 master2,
            IDungeon dungeon, 
            IPen pen, 
            IPaper paper)
        {
           
            _master2 = master2;
            _dungeon = dungeon;
            _paper = paper;
            _pen = pen;

        }
        public void Play() 
        { 
            
            _master2.Play();
            _dungeon.Play();
            _pen.Play();
            _paper.Play();
        }  
    }
}
