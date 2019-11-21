import * as _ from "lodash";

export function flatten(array) {
  return array.reduce(function (flat, toFlatten) {
    return flat.concat(Array.isArray(toFlatten) ? flatten(toFlatten) : toFlatten);
  }, []);
}

export function sortArrayByOrderProperty(a, b) {

  if (a.order > b.order) {
    return 1;
  } else if (a.order < b.order) {
    return -1;
  } else {
    return 0;
  }
}

export function sortBy(data: any[], props: string[]) {
    data = _.sortBy(data, props);
    return data;
}

export function isEmpty(array: any[]) {
  return !array || array.length == 0;
}
