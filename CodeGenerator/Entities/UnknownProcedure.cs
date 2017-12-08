using Triangle.AbstractMachine;

namespace Triangle.Compiler.CodeGenerator.Entities
{
    public class UnknownProcedure : RuntimeEntity, IProcedureEntity
    {

        readonly ObjectAddress _address;

        public UnknownProcedure(int size, int level, int displacement)
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
