namespace FourSix.Controllers.Presenters
{
    public sealed class Notification
    {

        private readonly IDictionary<string, IList<string>> _errorMessages = new Dictionary<string, IList<string>>();

        public IDictionary<string, string[]> ModelState
        {
            get
            {
                Dictionary<string, string[]> modelState = this._errorMessages
                    .ToDictionary(item => item.Key, item => item.Value.ToArray());

                return modelState;
            }
        }

        public bool IsValid => this._errorMessages.Count == 0;

        public bool IsInvalid => this._errorMessages.Count > 0;

        public void Add(string key, string message)
        {
            if (!this._errorMessages.ContainsKey(key))
            {
                this._errorMessages[key] = new List<string>();
            }

            this._errorMessages[key].Add(message);
        }
    }
}