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


export const blobToFile = (theBlob: Blob, fileName:string): File => {
  var b: any = theBlob;
  //A Blob() is almost a File() - it's just missing the two properties below which we will add
  b.lastModifiedDate = new Date();
  b.name = fileName;

  //Cast to a File() type
  return <File>theBlob;
}


export function randomColor1() {
  const goldenRatio = 0.618033988749895;
  let h = Math.random() * 100;

  h += goldenRatio;
  h %= 1;

  return hsvToRgb(h, 0.5, 0.8);
}

export function hsvToRgb(h, s, v) {
  let h_i = Math.round(h * 6);
  let f = h * 6 - h_i;
  let p = v * (1 - s);
  let q = v * (1 - f * s);
  let t = v * (1 - (1 - f) * s);
  let r, g, b = 0;

  switch (h_i) {
    case 0: r = v; g = t; b = p; break;
    case 1: r = q; g = v; b = p; break;
    case 2: r = p; g = v; b = t; break;
    case 3: r = p; g = q; b = v; break;
    case 4: r = t; g = p; b = v; break;
    case 5: r = v; g = p; b = q; break;
    default: break;
  }

  return "rgba(" + Math.round(r * 256) + "," + Math.round(g * 256) + "," + Math.round(b * 256) + "," + 1 + ")";
}

export function randomColor() {
  var r, g, b;
  var rand = () => Math.random() * 100;

  var h = rand() / rand();

  var i = ~~(h * 6);
  var f = h * 6 - i;
  var q = 1 - f;

  switch (i % 6) {
    case 0: r = 1; g = f; b = 0; break;
    case 1: r = q; g = 1; b = 0; break;
    case 2: r = 0; g = 1; b = f; break;
    case 3: r = 0; g = q; b = 1; break;
    case 4: r = f; g = 0; b = 1; break;
    case 5: r = 1; g = 0; b = q; break;
  }
  var c = "#" + ("00" + (~ ~(r * 255)).toString(16)).slice(-2) + ("00" + (~ ~(g * 255)).toString(16)).slice(-2) + ("00" + (~ ~(b * 255)).toString(16)).slice(-2);
  return (c);
}

