namespace Coding.Writers
{
    public class WriterContext
    {
        private readonly WriterContext parentContext;
        
        private readonly WriterContextFlags contextFlag;
        
        public WriterContext(WriterContextFlags flag)
        {
            contextFlag = flag;
        }

        private WriterContext(WriterContext parentContext, WriterContextFlags flag) : this(flag)
        {
            this.parentContext = parentContext;
        }

        public WriterContext Switch(WriterContextFlags flag)
        {
            return new WriterContext(this, flag);
        }

        public bool Is(WriterContextFlags flag, bool inherit = false)
        {
            return flag == contextFlag || (inherit && parentContext != null && parentContext.Is(flag));
        }
    }
}
