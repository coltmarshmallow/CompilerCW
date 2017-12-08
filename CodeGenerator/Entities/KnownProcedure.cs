using Triangle.AbstractMachine;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class KnownProcedure : RuntimeEntity, IProcedureEntity
    {

        readonly ObjectAddress _address;

        public KnownProcedure(int size, int level, int displacement)
            : base(size)
        {
            _address = new ObjectAddress(level, displacement);
        }

        public void EncodeCall(Emitter emitter, Frame frame)
        {
            
        }

        public void EncodeFetch(Emitter emitter, Frame frame)
        {
           
        }

    }
}