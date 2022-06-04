class RegionCell {
  x: number;
  y: number;
  topBorder: boolean;
  rightBorder: boolean;
  leftBorder: boolean;
  bottomBorder: boolean;

  constructor(x: number, y: number) {
    this.x = x;
    this.y = y;

  }
}

export { RegionCell }
