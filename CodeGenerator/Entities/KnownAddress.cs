using Triangle.AbstractMachine;
using Triangle.Compiler.SyntaxTrees.Vnames;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class KnownAddress : AddressableEntity
    {

        public KnownAddress(int size, int level, int displacement)
            : base(size, level, displacement)
        {
        }

        public KnownAddress(int size, Frame frame)
             : base(size, frame)
        {
        }

        public override void EncodeAssign(Emitter emitter, Frame frame, int size, Vname vname)
        {
            
        }

        public override void EncodeFetch(Emitter emitter, Frame frame, int size, Vname vname)
        {
            
        }

        public override void EncodeFetchAddress(Emitter emitter, Frame frame, Vname vname)
        {
            
        }
    }
}