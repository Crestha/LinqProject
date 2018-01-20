using LinqProject.Classes;
using System;

namespace LinqProject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region objects     
            AggregationOperations aggregation = new AggregationOperations();
            ConcatenationOperations concat = new ConcatenationOperations();
            ElementOperations element = new ElementOperations();
            EqualityOperations equality = new EqualityOperations();
            FilteringOperations filtering = new FilteringOperations();
            GenerationOperations generation = new GenerationOperations();
            GroupingOperations grouping = new GroupingOperations();
            JoinOperations join = new JoinOperations();
            PartitioningOperations partitioning = new PartitioningOperations();
            ProjectionOperations projection = new ProjectionOperations();
            QuantifierOperations quantifier = new QuantifierOperations();
            SetOperations set = new SetOperations();
            SortingOperations sorting = new SortingOperations();
            #endregion

            #region Aggregation(Aggregate,Average,Count,LongCount,Max,Min,Sum)
            aggregation.Aggregate();
            aggregation.Average();
            aggregation.Count();
            aggregation.LongCount();
            aggregation.Max();
            aggregation.Min();
            aggregation.Sum();
            #endregion

            #region Concatenation(Concat)
            concat.Concat();
            #endregion

            #region Element(ElementAt, ElementAtOrDefault, First, FirstOrDefault, Last, LastOrDefault, Single, SingleOrDefault)
            element.ElementAt();
            element.ElementAtOrDefault();
            element.First();
            element.FirstOrDefault();
            element.Last();
            element.LastOrDefault();
            element.Single();
            element.SingleOrDefault();
            #endregion

            #region Equality(SequenceEqual)
            equality.SequenceEqual();
            #endregion

            #region Filtering(Where,OfType)
            filtering.Where();
            filtering.OfType();
            #endregion

            #region Generation(DefaultIfEmpty,Empty,Range,Repeat)
            generation.DefaultIfEmpty();
            generation.Empty();
            generation.Range();
            generation.Repeat();
            #endregion

            #region Grouping(GroupBy,ToLookup)
            grouping.GroupBy();
            grouping.ToLookup();
            #endregion

            #region Joining(Join,GroupJoin)
            join.Join();
            join.GroupJoin();
            #endregion

            #region Partitioning(Take, TakeWhile, Skip, SkipWhile)
            partitioning.Take();
            partitioning.TakeWhile();
            partitioning.Skip();
            partitioning.SkipWhile();
            #endregion

            #region Projection(Select,SelectMany)
            projection.Select();
            projection.SelectMany();
            #endregion

            #region Quantifier(All, Any, Contains)
            quantifier.All();
            quantifier.Any();
            quantifier.Contains();
            #endregion

            #region Set(Distinct,Except,Intersect,Union)
            set.Distinct();
            set.Except();
            set.Intersect();
            set.Union();
            #endregion

            #region Sorting(OrderBy,OrderByDecending,ThenBy,ThenByDescending,Reverse)
            sorting.OrderBy();
            sorting.OrderByDecending();
            sorting.ThenBy();
            sorting.ThenByDescending();
            sorting.Reverse();
            #endregion

            Console.ReadLine();
        }
    }
}
