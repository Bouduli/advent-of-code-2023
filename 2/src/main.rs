use std::{fs, vec, borrow::BorrowMut, fmt::format};


fn main() {
    println!("Hello, world!");

    // fs::read_to_string("src/aoc2_test");
    let input: String = fs::read_to_string("src/aoc2_input").unwrap();
    let lines =input.lines();
    
    for s in lines{
        unsafe{

            lookAtString(s);
        }
    }

    // println!("{}",input);
}
unsafe
fn lookAtString(string: &str)->bool{
    let game: &str = string.split(": ").nth(1).unwrap();

    // let games: Vec<&mut &str> = game.split(";").into_iter().collect();
    let games: Vec<&str> = game.split(";").into_iter().collect();
    let formatted_games: &mut Vec<String> = &mut Vec::new();
    
    for s in games.into_iter(){
        if !s.contains("red"){
            formatted_games.push(("0 red".to_owned() + s));
        }
        if !s.contains("green"){
            if(s.contains("red")) {
                formatted_games.push(s.split("d,").nth(0).unwrap().to_owned() + "0 green" + s.split("d,").nth(1).unwrap());
            } else { formatted_games.push("0 green".to_owned() + s) }
        }
    }
    
    // print!("{:?}", games);
    
    panic!("hej");
    false
}