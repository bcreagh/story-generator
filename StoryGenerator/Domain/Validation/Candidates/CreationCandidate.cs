using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoryGenerator.Domain.Validation.Candidates
{
    public class CreationCandidate<T>
    {
        public T Candidate { get; set; }

        public CreationCandidate(T candidate)
        {
            Candidate = candidate;
        }
    }
}
