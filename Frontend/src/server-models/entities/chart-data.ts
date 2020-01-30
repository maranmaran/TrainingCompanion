export class ChartData<T> {
  labels: string[]
  dataSets: ChartDataSet<T>[]
}

export class ChartDataSet<T> {
  data: T[]
}

