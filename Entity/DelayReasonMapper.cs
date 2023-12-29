using DTO;

namespace Entity
{
    public static class DelayReasonMapper
    {
        public static DelayReasonEntity ModelToEntity(this DelayReason delay)
        {
            return new DelayReasonEntity
            {
                id = delay.id,
                name = delay.name,
                delay = delay.delay

            };
        }
        public static DelayReason EntityToModel(this DelayReasonEntity delay)
        {
            return new DelayReason
            {
                id = delay.id,
                name = delay.name,
                delay = delay.delay
            };
        }
    }
}
