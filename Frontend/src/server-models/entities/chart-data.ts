export class ChartData<TData, TLabel> {
  labels: TLabel[]
  dataSets: ChartDataSet<TData>[]
}

export class ChartDataSet<T> {
  data: T[]
}

