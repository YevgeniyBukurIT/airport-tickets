using DTO;

namespace Entity
{

    public static class PassangerMapper
    {
        public static PassangerEntity ModelToEntity(this Passanger pass)
        {
            return new PassangerEntity
            {
                id = pass.id,
                name = pass.name,
                surname = pass.surname

            };
        }
        public static Passanger EntityToModel(this PassangerEntity pass)
        {
            return new Passanger
            {
                id = pass.id,
                name = pass.name,
                surname = pass.surname
            };
        }
    }
}
