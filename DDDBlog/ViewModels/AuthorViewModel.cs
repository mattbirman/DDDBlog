using System;

namespace DDDBlog.ViewModels
{
    public class AuthorViewModel
    {
        public string Name { get; }
        
        public AuthorViewModel(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            
            Name = name;
        }
    }
}