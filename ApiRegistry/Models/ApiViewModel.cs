using System.Collections.Generic;

namespace ApiRegistry.Models
{
    public class ApiViewModel<T>
    {
        public T Data { get; private set; }
        public ICollection<Link> Controls { get; private set; }

        public ApiViewModel(T data, ApiControls controls)
        {
            Data = data;
            Controls = controls.Links;
        }
    }

    public class ApiForm<T>
    {
        public T Form { get; private set; }
        public ICollection<Link> Controls { get; private set; }

        public ApiForm(T form, ApiControls controls)
        {
            Form = form;
            Controls = controls.Links;
        }
    }
}