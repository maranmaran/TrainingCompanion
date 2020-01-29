export interface ChartDataSet<T> {
  data: T[]
}

export interface ChartData<T> {
  labels: string[],
  dataSets: ChartDataSet<T>[]
}
