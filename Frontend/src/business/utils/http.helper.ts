export function getFileNameFromHttpResponse(httpResponse) {
  var contentDispositionHeader = httpResponse.headers.get('Content-Disposition');
  var result = contentDispositionHeader.split(';')[1].trim().split('=')[1];
  return result.replace(/"/g, '');
}
