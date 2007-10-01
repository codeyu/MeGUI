using System;
using System.Collections.Generic;
using System.Text;

namespace MeGUI.core.details
{
    #region public part
    public abstract partial class JobChain {
        public static implicit operator JobChain(Job j)
        {
            return new JobDependencyChain(j);
        }
    }

    public sealed partial class SequentialChain : JobChain
    {
        public SequentialChain(params JobChain[] chains)
        {
            resolve(chains);
        }

        public SequentialChain(params Job[] jobs) : this(DUtil.convert(jobs)) { }
    }

    public sealed partial class ParallelChain : JobChain
    {
        public ParallelChain(params JobChain[] chains)
        {
            resolve(chains);
        }

        public ParallelChain(params Job[] jobs) : this(DUtil.convert(jobs)) {}
    }
    #endregion 

    #region private part
    class DUtil
    {
        internal static JobChain[] convert(Job[] jobs)
        {
            JobChain[] d = new JobChain[jobs.Length];
            for (int i = 0; i < jobs.Length; ++i)
                d[i] = jobs[i];

            return d;
        }
    }
    internal delegate void MakeDependant(TaggedJob j);

    partial class JobChain
    {
        internal abstract TaggedJob[] Jobs { get; }
        internal abstract void MakeJobDependOnChain(TaggedJob allowedEnd);
        internal abstract void MakeStartDepend(MakeDependant requiredEnd);
    }

    internal sealed class JobDependencyChain : JobChain
    {
        internal TaggedJob j;
        internal TaggedJob[] jobs;

        internal JobDependencyChain(Job j)
        {
            this.j = new TaggedJob(j);
            jobs = new TaggedJob[] { this.j };
        }

        internal override TaggedJob[] Jobs
        {
            get
            {
                return jobs;
            }
        }

        internal override void MakeJobDependOnChain(TaggedJob allowedEnd)
        {
            allowedEnd.AddDependency(j);
        }

        internal override void MakeStartDepend(MakeDependant requiredEnd)
        {
            requiredEnd(j);
        }
    }

    partial class ParallelChain {
        private TaggedJob[] jobs;
        private JobChain[] chains;

        private void resolve(JobChain[] chains)
        {
            this.chains = chains;

            List<TaggedJob> jobsConstructor = new List<TaggedJob>();
            foreach (JobChain chain in chains)
                jobsConstructor.AddRange(chain.Jobs);

            jobs = jobsConstructor.ToArray();
        }

        internal override TaggedJob[] Jobs
        {
            get { return jobs; }
        }

        internal override void MakeJobDependOnChain(TaggedJob j)
        {
            foreach (JobChain c in chains)
                c.MakeJobDependOnChain(j);
        }

        internal override void MakeStartDepend(MakeDependant requiredEnd)
        {
            foreach (JobChain c in chains)
                c.MakeStartDepend(requiredEnd);
        }
    }

    partial class SequentialChain 
    {
        private TaggedJob[] jobs;
        private JobChain first;
        private JobChain last;

        private void resolve(JobChain[] chains)
        {
            List<TaggedJob> jobs = new List<TaggedJob>();
            JobChain last = null;

            foreach (JobChain c in chains)
            {
                TaggedJob[] cjobs = c.Jobs;
                if (last != null)
                    c.MakeStartDepend(new MakeDependant(last.MakeJobDependOnChain));
                jobs.AddRange(cjobs);
            }
            this.jobs = jobs.ToArray();
            first = chains[0];
            last = chains[chains.Length - 1];
        }

        internal override TaggedJob[] Jobs
        {
            get { return jobs; }
        }

        internal override void MakeJobDependOnChain(TaggedJob j)
        {
            last.MakeJobDependOnChain(j);
        }

        internal override void MakeStartDepend(MakeDependant requiredEnd)
        {
            first.MakeStartDepend(requiredEnd);
        }

    }
    
    #endregion

}
