// Implementation file for parser generated by fsyacc
module FunPar
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "FunPar.fsy"

 (* File Fun/FunPar.fsy 
    Parser for micro-ML, a small functional language; one-argument functions.
    sestoft@itu.dk * 2009-10-19
  *)

 open Absyn;

# 15 "FunPar.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | EOF
  | LPAR
  | RPAR
  | EQ
  | NE
  | GT
  | LT
  | GE
  | LE
  | PLUS
  | MINUS
  | TIMES
  | DIV
  | MOD
  | ELSE
  | END
  | FALSE
  | IF
  | IN
  | LET
  | NOT
  | THEN
  | TRUE
  | COMMA
  | FST
  | SND
  | CSTBOOL of (bool)
  | NAME of (string)
  | CSTINT of (int)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_EOF
    | TOKEN_LPAR
    | TOKEN_RPAR
    | TOKEN_EQ
    | TOKEN_NE
    | TOKEN_GT
    | TOKEN_LT
    | TOKEN_GE
    | TOKEN_LE
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_TIMES
    | TOKEN_DIV
    | TOKEN_MOD
    | TOKEN_ELSE
    | TOKEN_END
    | TOKEN_FALSE
    | TOKEN_IF
    | TOKEN_IN
    | TOKEN_LET
    | TOKEN_NOT
    | TOKEN_THEN
    | TOKEN_TRUE
    | TOKEN_COMMA
    | TOKEN_FST
    | TOKEN_SND
    | TOKEN_CSTBOOL
    | TOKEN_NAME
    | TOKEN_CSTINT
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startMain
    | NONTERM_Main
    | NONTERM_Expr
    | NONTERM_AtExpr
    | NONTERM_AppExpr
    | NONTERM_Const

// This function maps tokens to integers indexes
let tagOfToken (t:token) = 
  match t with
  | EOF  -> 0 
  | LPAR  -> 1 
  | RPAR  -> 2 
  | EQ  -> 3 
  | NE  -> 4 
  | GT  -> 5 
  | LT  -> 6 
  | GE  -> 7 
  | LE  -> 8 
  | PLUS  -> 9 
  | MINUS  -> 10 
  | TIMES  -> 11 
  | DIV  -> 12 
  | MOD  -> 13 
  | ELSE  -> 14 
  | END  -> 15 
  | FALSE  -> 16 
  | IF  -> 17 
  | IN  -> 18 
  | LET  -> 19 
  | NOT  -> 20 
  | THEN  -> 21 
  | TRUE  -> 22 
  | COMMA  -> 23 
  | FST  -> 24 
  | SND  -> 25 
  | CSTBOOL _ -> 26 
  | NAME _ -> 27 
  | CSTINT _ -> 28 

// This function maps integers indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_EOF 
  | 1 -> TOKEN_LPAR 
  | 2 -> TOKEN_RPAR 
  | 3 -> TOKEN_EQ 
  | 4 -> TOKEN_NE 
  | 5 -> TOKEN_GT 
  | 6 -> TOKEN_LT 
  | 7 -> TOKEN_GE 
  | 8 -> TOKEN_LE 
  | 9 -> TOKEN_PLUS 
  | 10 -> TOKEN_MINUS 
  | 11 -> TOKEN_TIMES 
  | 12 -> TOKEN_DIV 
  | 13 -> TOKEN_MOD 
  | 14 -> TOKEN_ELSE 
  | 15 -> TOKEN_END 
  | 16 -> TOKEN_FALSE 
  | 17 -> TOKEN_IF 
  | 18 -> TOKEN_IN 
  | 19 -> TOKEN_LET 
  | 20 -> TOKEN_NOT 
  | 21 -> TOKEN_THEN 
  | 22 -> TOKEN_TRUE 
  | 23 -> TOKEN_COMMA 
  | 24 -> TOKEN_FST 
  | 25 -> TOKEN_SND 
  | 26 -> TOKEN_CSTBOOL 
  | 27 -> TOKEN_NAME 
  | 28 -> TOKEN_CSTINT 
  | 31 -> TOKEN_end_of_input
  | 29 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startMain 
    | 1 -> NONTERM_Main 
    | 2 -> NONTERM_Expr 
    | 3 -> NONTERM_Expr 
    | 4 -> NONTERM_Expr 
    | 5 -> NONTERM_Expr 
    | 6 -> NONTERM_Expr 
    | 7 -> NONTERM_Expr 
    | 8 -> NONTERM_Expr 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_AtExpr 
    | 20 -> NONTERM_AtExpr 
    | 21 -> NONTERM_AtExpr 
    | 22 -> NONTERM_AtExpr 
    | 23 -> NONTERM_AtExpr 
    | 24 -> NONTERM_AppExpr 
    | 25 -> NONTERM_AppExpr 
    | 26 -> NONTERM_Const 
    | 27 -> NONTERM_Const 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 31 
let _fsyacc_tagOfErrorTerminal = 29

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | EOF  -> "EOF" 
  | LPAR  -> "LPAR" 
  | RPAR  -> "RPAR" 
  | EQ  -> "EQ" 
  | NE  -> "NE" 
  | GT  -> "GT" 
  | LT  -> "LT" 
  | GE  -> "GE" 
  | LE  -> "LE" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | TIMES  -> "TIMES" 
  | DIV  -> "DIV" 
  | MOD  -> "MOD" 
  | ELSE  -> "ELSE" 
  | END  -> "END" 
  | FALSE  -> "FALSE" 
  | IF  -> "IF" 
  | IN  -> "IN" 
  | LET  -> "LET" 
  | NOT  -> "NOT" 
  | THEN  -> "THEN" 
  | TRUE  -> "TRUE" 
  | COMMA  -> "COMMA" 
  | FST  -> "FST" 
  | SND  -> "SND" 
  | CSTBOOL _ -> "CSTBOOL" 
  | NAME _ -> "NAME" 
  | CSTINT _ -> "CSTINT" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | EOF  -> (null : System.Object) 
  | LPAR  -> (null : System.Object) 
  | RPAR  -> (null : System.Object) 
  | EQ  -> (null : System.Object) 
  | NE  -> (null : System.Object) 
  | GT  -> (null : System.Object) 
  | LT  -> (null : System.Object) 
  | GE  -> (null : System.Object) 
  | LE  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | TIMES  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | MOD  -> (null : System.Object) 
  | ELSE  -> (null : System.Object) 
  | END  -> (null : System.Object) 
  | FALSE  -> (null : System.Object) 
  | IF  -> (null : System.Object) 
  | IN  -> (null : System.Object) 
  | LET  -> (null : System.Object) 
  | NOT  -> (null : System.Object) 
  | THEN  -> (null : System.Object) 
  | TRUE  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | FST  -> (null : System.Object) 
  | SND  -> (null : System.Object) 
  | CSTBOOL _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | NAME _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | CSTINT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 0us; 1us; 24us; 65535us; 0us; 2us; 6us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 17us; 18us; 19us; 20us; 37us; 21us; 38us; 22us; 39us; 23us; 40us; 24us; 41us; 25us; 42us; 26us; 43us; 27us; 44us; 28us; 45us; 29us; 46us; 30us; 47us; 31us; 52us; 32us; 53us; 33us; 56us; 34us; 57us; 35us; 59us; 36us; 26us; 65535us; 0us; 4us; 4us; 61us; 5us; 62us; 6us; 4us; 8us; 4us; 10us; 4us; 12us; 4us; 14us; 4us; 17us; 4us; 19us; 4us; 37us; 4us; 38us; 4us; 39us; 4us; 40us; 4us; 41us; 4us; 42us; 4us; 43us; 4us; 44us; 4us; 45us; 4us; 46us; 4us; 47us; 4us; 52us; 4us; 53us; 4us; 56us; 4us; 57us; 4us; 59us; 4us; 24us; 65535us; 0us; 5us; 6us; 5us; 8us; 5us; 10us; 5us; 12us; 5us; 14us; 5us; 17us; 5us; 19us; 5us; 37us; 5us; 38us; 5us; 39us; 5us; 40us; 5us; 41us; 5us; 42us; 5us; 43us; 5us; 44us; 5us; 45us; 5us; 46us; 5us; 47us; 5us; 52us; 5us; 53us; 5us; 56us; 5us; 57us; 5us; 59us; 5us; 26us; 65535us; 0us; 48us; 4us; 48us; 5us; 48us; 6us; 48us; 8us; 48us; 10us; 48us; 12us; 48us; 14us; 48us; 17us; 48us; 19us; 48us; 37us; 48us; 38us; 48us; 39us; 48us; 40us; 48us; 41us; 48us; 42us; 48us; 43us; 48us; 44us; 48us; 45us; 48us; 46us; 48us; 47us; 48us; 52us; 48us; 53us; 48us; 56us; 48us; 57us; 48us; 59us; 48us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 28us; 55us; 80us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 12us; 1us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 1us; 2us; 2us; 24us; 2us; 3us; 25us; 1us; 4us; 12us; 4us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 4us; 12us; 4us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 4us; 12us; 4us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 2us; 5us; 23us; 13us; 5us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 23us; 1us; 5us; 12us; 5us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 5us; 1us; 6us; 12us; 6us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 1us; 7us; 12us; 7us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 13us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 14us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 15us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 16us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 17us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 18us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 21us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 21us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 22us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 22us; 12us; 8us; 9us; 10us; 11us; 12us; 13us; 14us; 15us; 16us; 17us; 18us; 23us; 1us; 8us; 1us; 9us; 1us; 10us; 1us; 11us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 18us; 1us; 19us; 1us; 20us; 2us; 21us; 22us; 2us; 21us; 22us; 1us; 21us; 1us; 21us; 1us; 21us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 22us; 1us; 23us; 1us; 23us; 1us; 24us; 1us; 25us; 1us; 26us; 1us; 27us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 17us; 19us; 22us; 25us; 27us; 40us; 42us; 55us; 57us; 70us; 73us; 87us; 89us; 102us; 104us; 106us; 119us; 121us; 134us; 147us; 160us; 173us; 186us; 199us; 212us; 225us; 238us; 251us; 264us; 277us; 290us; 303us; 316us; 329us; 342us; 344us; 346us; 348us; 350us; 352us; 354us; 356us; 358us; 360us; 362us; 364us; 366us; 368us; 371us; 374us; 376us; 378us; 380us; 382us; 384us; 386us; 388us; 390us; 392us; 394us; 396us; 398us; |]
let _fsyacc_action_rows = 65
let _fsyacc_actionTableElements = [|8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 0us; 49152us; 12us; 32768us; 0us; 3us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 0us; 16385us; 5us; 16386us; 1us; 59us; 19us; 50us; 26us; 64us; 27us; 49us; 28us; 63us; 5us; 16387us; 1us; 59us; 19us; 50us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 12us; 32768us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 21us; 8us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 12us; 32768us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 14us; 10us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 11us; 16388us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 13us; 32768us; 2us; 60us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 23us; 14us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 12us; 32768us; 2us; 16us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 0us; 16389us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 11us; 16390us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 11us; 16391us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 3us; 16392us; 11us; 39us; 12us; 40us; 13us; 41us; 3us; 16393us; 11us; 39us; 12us; 40us; 13us; 41us; 0us; 16394us; 0us; 16395us; 0us; 16396us; 9us; 16397us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 9us; 16398us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 9us; 16399us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 9us; 16400us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 9us; 16401us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 9us; 16402us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 12us; 32768us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 18us; 53us; 12us; 32768us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 15us; 54us; 12us; 32768us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 18us; 57us; 12us; 32768us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 15us; 58us; 12us; 32768us; 2us; 60us; 3us; 42us; 4us; 43us; 5us; 44us; 6us; 45us; 7us; 46us; 8us; 47us; 9us; 37us; 10us; 38us; 11us; 39us; 12us; 40us; 13us; 41us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 0us; 16403us; 0us; 16404us; 1us; 32768us; 27us; 51us; 2us; 32768us; 3us; 52us; 27us; 55us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 0us; 16405us; 1us; 32768us; 3us; 56us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 0us; 16406us; 8us; 32768us; 1us; 12us; 17us; 6us; 19us; 50us; 24us; 17us; 25us; 19us; 26us; 64us; 27us; 49us; 28us; 63us; 0us; 16407us; 0us; 16408us; 0us; 16409us; 0us; 16410us; 0us; 16411us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 9us; 10us; 23us; 24us; 30us; 36us; 45us; 58us; 67us; 80us; 89us; 101us; 110us; 124us; 133us; 146us; 147us; 156us; 168us; 177us; 189us; 193us; 197us; 198us; 199us; 200us; 210us; 220us; 230us; 240us; 250us; 260us; 273us; 286us; 299us; 312us; 325us; 334us; 343us; 352us; 361us; 370us; 379us; 388us; 397us; 406us; 415us; 424us; 425us; 426us; 428us; 431us; 440us; 449us; 450us; 452us; 461us; 470us; 471us; 480us; 481us; 482us; 483us; 484us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 2us; 1us; 1us; 6us; 5us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 3us; 1us; 1us; 7us; 8us; 3us; 2us; 2us; 1us; 1us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 2us; 3us; 3us; 3us; 3us; 3us; 4us; 4us; 5us; 5us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 16385us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16389us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16403us; 16404us; 65535us; 65535us; 65535us; 65535us; 16405us; 65535us; 65535us; 65535us; 16406us; 65535us; 16407us; 16408us; 16409us; 16410us; 16411us; |]
let _fsyacc_reductions ()  =    [| 
# 270 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startMain));
# 279 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 34 "FunPar.fsy"
                                                               _1 
                   )
# 34 "FunPar.fsy"
                 : Absyn.expr));
# 290 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 38 "FunPar.fsy"
                                                               _1                     
                   )
# 38 "FunPar.fsy"
                 : Absyn.expr));
# 301 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 39 "FunPar.fsy"
                                                               _1                     
                   )
# 39 "FunPar.fsy"
                 : Absyn.expr));
# 312 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "FunPar.fsy"
                                                               If(_2, _4, _6)         
                   )
# 40 "FunPar.fsy"
                 : Absyn.expr));
# 325 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 41 "FunPar.fsy"
                                                               Pair(_2,_4)            
                   )
# 41 "FunPar.fsy"
                 : Absyn.expr));
# 337 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "FunPar.fsy"
                                                               Fst(_2)                
                   )
# 42 "FunPar.fsy"
                 : Absyn.expr));
# 348 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 43 "FunPar.fsy"
                                                               Snd(_2)                
                   )
# 43 "FunPar.fsy"
                 : Absyn.expr));
# 359 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 44 "FunPar.fsy"
                                                               Prim("+",  _1, _3)     
                   )
# 44 "FunPar.fsy"
                 : Absyn.expr));
# 371 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "FunPar.fsy"
                                                               Prim("-",  _1, _3)     
                   )
# 45 "FunPar.fsy"
                 : Absyn.expr));
# 383 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "FunPar.fsy"
                                                               Prim("*",  _1, _3)     
                   )
# 46 "FunPar.fsy"
                 : Absyn.expr));
# 395 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "FunPar.fsy"
                                                               Prim("/",  _1, _3)     
                   )
# 47 "FunPar.fsy"
                 : Absyn.expr));
# 407 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "FunPar.fsy"
                                                               Prim("%",  _1, _3)     
                   )
# 48 "FunPar.fsy"
                 : Absyn.expr));
# 419 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "FunPar.fsy"
                                                               Prim("=",  _1, _3)     
                   )
# 49 "FunPar.fsy"
                 : Absyn.expr));
# 431 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "FunPar.fsy"
                                                               Prim("<>", _1, _3)     
                   )
# 50 "FunPar.fsy"
                 : Absyn.expr));
# 443 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "FunPar.fsy"
                                                               Prim(">",  _1, _3)     
                   )
# 51 "FunPar.fsy"
                 : Absyn.expr));
# 455 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "FunPar.fsy"
                                                               Prim("<",  _1, _3)     
                   )
# 52 "FunPar.fsy"
                 : Absyn.expr));
# 467 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "FunPar.fsy"
                                                               Prim(">=", _1, _3)     
                   )
# 53 "FunPar.fsy"
                 : Absyn.expr));
# 479 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "FunPar.fsy"
                                                               Prim("<=", _1, _3)     
                   )
# 54 "FunPar.fsy"
                 : Absyn.expr));
# 491 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "FunPar.fsy"
                                                               _1                     
                   )
# 58 "FunPar.fsy"
                 : Absyn.expr));
# 502 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "FunPar.fsy"
                                                               Var _1                 
                   )
# 59 "FunPar.fsy"
                 : Absyn.expr));
# 513 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _4 = (let data = parseState.GetInput(4) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 60 "FunPar.fsy"
                                                               Let(_2, _4, _6)        
                   )
# 60 "FunPar.fsy"
                 : Absyn.expr));
# 526 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _5 = (let data = parseState.GetInput(5) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _7 = (let data = parseState.GetInput(7) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 61 "FunPar.fsy"
                                                               Letfun(_2, _3, _5, _7) 
                   )
# 61 "FunPar.fsy"
                 : Absyn.expr));
# 540 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 62 "FunPar.fsy"
                                                               _2                     
                   )
# 62 "FunPar.fsy"
                 : Absyn.expr));
# 551 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 66 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 66 "FunPar.fsy"
                 : Absyn.expr));
# 563 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : Absyn.expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 67 "FunPar.fsy"
                                                               Call(_1, _2)           
                   )
# 67 "FunPar.fsy"
                 : Absyn.expr));
# 575 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 71 "FunPar.fsy"
                                                               CstI(_1)               
                   )
# 71 "FunPar.fsy"
                 : Absyn.expr));
# 586 "FunPar.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : bool)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 72 "FunPar.fsy"
                                                               CstB(_1)               
                   )
# 72 "FunPar.fsy"
                 : Absyn.expr));
|]
# 598 "FunPar.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 32;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let Main lexer lexbuf : Absyn.expr =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))