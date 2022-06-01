class Cell {
  constructor(value?: number, notes? : number[], state?: string) {
    this.value = value;
    this.notes = notes;
    this.state = state;
  }
  value? : number;
  notes? : number[];
  state? : string = 'empty';

}

export { Cell };
