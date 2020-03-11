export interface FileContentResult {
  fileContents: Blob
  contentType: string
  fileDownloadName: string
  lastModified: Date
  entityTag: string
  enableRangeProcessing: boolean
}
