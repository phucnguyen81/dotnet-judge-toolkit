namespace Judge
{
    /**
     * Generic response from judge API
     */
    public class Response<T>
    {
        public bool IsSuccess = false;
        public string StatusCode = "";
        public string StatusMessage = "";
        public T Model;

        public override string ToString() {
            string msg = @"Response(
                    IsSuccess = {0},
                    StatusCode = {1},
                    StatusMessage = {2},
                    Model = {3}
                    )";
            object[] arg = new object[] {
                this.IsSuccess,
                this.StatusCode,
                this.StatusMessage,
                this.Model
            };
            return string.Format(msg, arg);
        }
    }
}

