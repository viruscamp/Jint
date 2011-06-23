// $ANTLR 3.3.0.7239 C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g 2011-06-23 13:14:45

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "3.3.0.7239")]
[System.CLSCompliant(false)]
public partial class ES3Lexer : Antlr.Runtime.Lexer
{
	public const int EOF=-1;
	public const int ABSTRACT=4;
	public const int ADD=5;
	public const int ADDASS=6;
	public const int AND=7;
	public const int ANDASS=8;
	public const int ARGS=9;
	public const int ARRAY=10;
	public const int ASSIGN=11;
	public const int BLOCK=12;
	public const int BOOLEAN=13;
	public const int BREAK=14;
	public const int BSLASH=15;
	public const int BYFIELD=16;
	public const int BYINDEX=17;
	public const int BYTE=18;
	public const int BackslashSequence=19;
	public const int CALL=20;
	public const int CASE=21;
	public const int CATCH=22;
	public const int CEXPR=23;
	public const int CHAR=24;
	public const int CLASS=25;
	public const int COLON=26;
	public const int COMMA=27;
	public const int CONST=28;
	public const int CONTINUE=29;
	public const int CR=30;
	public const int CharacterEscapeSequence=31;
	public const int DEBUGGER=32;
	public const int DEC=33;
	public const int DEFAULT=34;
	public const int DELETE=35;
	public const int DIV=36;
	public const int DIVASS=37;
	public const int DO=38;
	public const int DOT=39;
	public const int DOUBLE=40;
	public const int DQUOTE=41;
	public const int DecimalDigit=42;
	public const int DecimalIntegerLiteral=43;
	public const int DecimalLiteral=44;
	public const int ELSE=45;
	public const int ENUM=46;
	public const int EOL=47;
	public const int EQ=48;
	public const int EXPORT=49;
	public const int EXPR=50;
	public const int EXTENDS=51;
	public const int EscapeSequence=52;
	public const int ExponentPart=53;
	public const int FALSE=54;
	public const int FF=55;
	public const int FINAL=56;
	public const int FINALLY=57;
	public const int FLOAT=58;
	public const int FOR=59;
	public const int FORITER=60;
	public const int FORSTEP=61;
	public const int FUNCTION=62;
	public const int GOTO=63;
	public const int GT=64;
	public const int GTE=65;
	public const int HexDigit=66;
	public const int HexEscapeSequence=67;
	public const int HexIntegerLiteral=68;
	public const int IF=69;
	public const int IMPLEMENTS=70;
	public const int IMPORT=71;
	public const int IN=72;
	public const int INC=73;
	public const int INSTANCEOF=74;
	public const int INT=75;
	public const int INTERFACE=76;
	public const int INV=77;
	public const int ITEM=78;
	public const int Identifier=79;
	public const int IdentifierNameASCIIStart=80;
	public const int IdentifierPart=81;
	public const int IdentifierStartASCII=82;
	public const int LABELLED=83;
	public const int LAND=84;
	public const int LBRACE=85;
	public const int LBRACK=86;
	public const int LF=87;
	public const int LONG=88;
	public const int LOR=89;
	public const int LPAREN=90;
	public const int LS=91;
	public const int LT=92;
	public const int LTE=93;
	public const int LineTerminator=94;
	public const int MOD=95;
	public const int MODASS=96;
	public const int MUL=97;
	public const int MULASS=98;
	public const int MultiLineComment=99;
	public const int NAMEDVALUE=100;
	public const int NATIVE=101;
	public const int NBSP=102;
	public const int NEG=103;
	public const int NEQ=104;
	public const int NEW=105;
	public const int NOT=106;
	public const int NSAME=107;
	public const int NULL=108;
	public const int OBJECT=109;
	public const int OR=110;
	public const int ORASS=111;
	public const int OctalDigit=112;
	public const int OctalEscapeSequence=113;
	public const int OctalIntegerLiteral=114;
	public const int PACKAGE=115;
	public const int PAREXPR=116;
	public const int PDEC=117;
	public const int PINC=118;
	public const int POS=119;
	public const int PRIVATE=120;
	public const int PROTECTED=121;
	public const int PS=122;
	public const int PUBLIC=123;
	public const int QUE=124;
	public const int RBRACE=125;
	public const int RBRACK=126;
	public const int RETURN=127;
	public const int RPAREN=128;
	public const int RegularExpressionChar=129;
	public const int RegularExpressionFirstChar=130;
	public const int RegularExpressionLiteral=131;
	public const int SAME=132;
	public const int SEMIC=133;
	public const int SHL=134;
	public const int SHLASS=135;
	public const int SHORT=136;
	public const int SHR=137;
	public const int SHRASS=138;
	public const int SHU=139;
	public const int SHUASS=140;
	public const int SP=141;
	public const int SQUOTE=142;
	public const int STATIC=143;
	public const int SUB=144;
	public const int SUBASS=145;
	public const int SUPER=146;
	public const int SWITCH=147;
	public const int SYNCHRONIZED=148;
	public const int SingleLineComment=149;
	public const int StringLiteral=150;
	public const int TAB=151;
	public const int THIS=152;
	public const int THROW=153;
	public const int THROWS=154;
	public const int TRANSIENT=155;
	public const int TRUE=156;
	public const int TRY=157;
	public const int TYPEOF=158;
	public const int USP=159;
	public const int UnicodeEscapeSequence=160;
	public const int VAR=161;
	public const int VOID=162;
	public const int VOLATILE=163;
	public const int VT=164;
	public const int WHILE=165;
	public const int WITH=166;
	public const int WhiteSpace=167;
	public const int XOR=168;
	public const int XORASS=169;
	public const int ZeroToThree=170;

	    private IToken last;

	    private bool AreRegularExpressionsEnabled()
	    {
	    	if (last == null)
	    	{
	    		return true;
	    	}
	    	switch (last.Type)
	    	{
	    	// identifier
	    		case Identifier:
	    	// literals
	    		case NULL:
	    		case TRUE:
	    		case FALSE:
	    		case THIS:
	    		case OctalIntegerLiteral:
	    		case DecimalLiteral:
	    		case HexIntegerLiteral:
	    		case StringLiteral:
	    	// member access ending 
	    		case RBRACK:
	    	// function call or nested expression ending
	    		case RPAREN:
	    			return false;
	    	// otherwise OK
	    		default:
	    			return true;
	    	}
	    }
	    	
	    private void ConsumeIdentifierUnicodeStart()
	    {
	    	int ch = input.LA(1);
	    	if (IsIdentifierStartUnicode(ch))
	    	{
	    		MatchAny();
	    		do
	    		{
	    			ch = input.LA(1);
	    			if (ch == '$' || (ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || ch == '\\' || ch == '_' || (ch >= 'a' && ch <= 'z') || IsIdentifierPartUnicode(ch))
	    			{
	    				mIdentifierPart();
	    			}
	    			else
	    			{
	    				return;
	    			}
	    		}
	    		while (true);
	    	}
	    	else
	    	{
	    		throw new NoViableAltException();
	    	}
	    }

	    private bool IsIdentifierPartUnicode(int ch)
	    {
	        return char.IsLetterOrDigit((char)ch);
	    }

	    private bool IsIdentifierStartUnicode(int ch)
	    {
	        return char.IsLetter((char)ch);
	    }

	    public override IToken NextToken()
	    {
	    	IToken result = base.NextToken();
	    	if (result.Channel == DefaultTokenChannel)
	    	{
	    		last = result;
	    	}
	    	return result;		
	    }
	   


    // delegates
    // delegators

	public ES3Lexer()
	{
		OnCreated();
	}

	public ES3Lexer(ICharStream input )
		: this(input, new RecognizerSharedState())
	{
	}

	public ES3Lexer(ICharStream input, RecognizerSharedState state)
		: base(input, state)
	{


		OnCreated();
	}
	public override string GrammarFileName { get { return "C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g"; } }

	private static readonly bool[] decisionCanBacktrack = new bool[0];


	partial void OnCreated();
	partial void EnterRule(string ruleName, int ruleIndex);
	partial void LeaveRule(string ruleName, int ruleIndex);

	partial void Enter_ABSTRACT();
	partial void Leave_ABSTRACT();

	// $ANTLR start "ABSTRACT"
	[GrammarRule("ABSTRACT")]
	private void mABSTRACT()
	{
		Enter_ABSTRACT();
		EnterRule("ABSTRACT", 1);
		TraceIn("ABSTRACT", 1);
		try
		{
			int _type = ABSTRACT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:88:10: ( 'abstract' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:88:12: 'abstract'
			{
			DebugLocation(88, 12);
			Match("abstract"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ABSTRACT", 1);
			LeaveRule("ABSTRACT", 1);
			Leave_ABSTRACT();
		}
	}
	// $ANTLR end "ABSTRACT"

	partial void Enter_ADD();
	partial void Leave_ADD();

	// $ANTLR start "ADD"
	[GrammarRule("ADD")]
	private void mADD()
	{
		Enter_ADD();
		EnterRule("ADD", 2);
		TraceIn("ADD", 2);
		try
		{
			int _type = ADD;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:89:5: ( '+' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:89:7: '+'
			{
			DebugLocation(89, 7);
			Match('+'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ADD", 2);
			LeaveRule("ADD", 2);
			Leave_ADD();
		}
	}
	// $ANTLR end "ADD"

	partial void Enter_ADDASS();
	partial void Leave_ADDASS();

	// $ANTLR start "ADDASS"
	[GrammarRule("ADDASS")]
	private void mADDASS()
	{
		Enter_ADDASS();
		EnterRule("ADDASS", 3);
		TraceIn("ADDASS", 3);
		try
		{
			int _type = ADDASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:90:8: ( '+=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:90:10: '+='
			{
			DebugLocation(90, 10);
			Match("+="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ADDASS", 3);
			LeaveRule("ADDASS", 3);
			Leave_ADDASS();
		}
	}
	// $ANTLR end "ADDASS"

	partial void Enter_AND();
	partial void Leave_AND();

	// $ANTLR start "AND"
	[GrammarRule("AND")]
	private void mAND()
	{
		Enter_AND();
		EnterRule("AND", 4);
		TraceIn("AND", 4);
		try
		{
			int _type = AND;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:91:5: ( '&' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:91:7: '&'
			{
			DebugLocation(91, 7);
			Match('&'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("AND", 4);
			LeaveRule("AND", 4);
			Leave_AND();
		}
	}
	// $ANTLR end "AND"

	partial void Enter_ANDASS();
	partial void Leave_ANDASS();

	// $ANTLR start "ANDASS"
	[GrammarRule("ANDASS")]
	private void mANDASS()
	{
		Enter_ANDASS();
		EnterRule("ANDASS", 5);
		TraceIn("ANDASS", 5);
		try
		{
			int _type = ANDASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:92:8: ( '&=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:92:10: '&='
			{
			DebugLocation(92, 10);
			Match("&="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ANDASS", 5);
			LeaveRule("ANDASS", 5);
			Leave_ANDASS();
		}
	}
	// $ANTLR end "ANDASS"

	partial void Enter_ASSIGN();
	partial void Leave_ASSIGN();

	// $ANTLR start "ASSIGN"
	[GrammarRule("ASSIGN")]
	private void mASSIGN()
	{
		Enter_ASSIGN();
		EnterRule("ASSIGN", 6);
		TraceIn("ASSIGN", 6);
		try
		{
			int _type = ASSIGN;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:93:8: ( '=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:93:10: '='
			{
			DebugLocation(93, 10);
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ASSIGN", 6);
			LeaveRule("ASSIGN", 6);
			Leave_ASSIGN();
		}
	}
	// $ANTLR end "ASSIGN"

	partial void Enter_BOOLEAN();
	partial void Leave_BOOLEAN();

	// $ANTLR start "BOOLEAN"
	[GrammarRule("BOOLEAN")]
	private void mBOOLEAN()
	{
		Enter_BOOLEAN();
		EnterRule("BOOLEAN", 7);
		TraceIn("BOOLEAN", 7);
		try
		{
			int _type = BOOLEAN;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:94:9: ( 'boolean' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:94:11: 'boolean'
			{
			DebugLocation(94, 11);
			Match("boolean"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BOOLEAN", 7);
			LeaveRule("BOOLEAN", 7);
			Leave_BOOLEAN();
		}
	}
	// $ANTLR end "BOOLEAN"

	partial void Enter_BREAK();
	partial void Leave_BREAK();

	// $ANTLR start "BREAK"
	[GrammarRule("BREAK")]
	private void mBREAK()
	{
		Enter_BREAK();
		EnterRule("BREAK", 8);
		TraceIn("BREAK", 8);
		try
		{
			int _type = BREAK;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:95:7: ( 'break' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:95:9: 'break'
			{
			DebugLocation(95, 9);
			Match("break"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BREAK", 8);
			LeaveRule("BREAK", 8);
			Leave_BREAK();
		}
	}
	// $ANTLR end "BREAK"

	partial void Enter_BYTE();
	partial void Leave_BYTE();

	// $ANTLR start "BYTE"
	[GrammarRule("BYTE")]
	private void mBYTE()
	{
		Enter_BYTE();
		EnterRule("BYTE", 9);
		TraceIn("BYTE", 9);
		try
		{
			int _type = BYTE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:96:6: ( 'byte' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:96:8: 'byte'
			{
			DebugLocation(96, 8);
			Match("byte"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("BYTE", 9);
			LeaveRule("BYTE", 9);
			Leave_BYTE();
		}
	}
	// $ANTLR end "BYTE"

	partial void Enter_CASE();
	partial void Leave_CASE();

	// $ANTLR start "CASE"
	[GrammarRule("CASE")]
	private void mCASE()
	{
		Enter_CASE();
		EnterRule("CASE", 10);
		TraceIn("CASE", 10);
		try
		{
			int _type = CASE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:97:6: ( 'case' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:97:8: 'case'
			{
			DebugLocation(97, 8);
			Match("case"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CASE", 10);
			LeaveRule("CASE", 10);
			Leave_CASE();
		}
	}
	// $ANTLR end "CASE"

	partial void Enter_CATCH();
	partial void Leave_CATCH();

	// $ANTLR start "CATCH"
	[GrammarRule("CATCH")]
	private void mCATCH()
	{
		Enter_CATCH();
		EnterRule("CATCH", 11);
		TraceIn("CATCH", 11);
		try
		{
			int _type = CATCH;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:98:7: ( 'catch' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:98:9: 'catch'
			{
			DebugLocation(98, 9);
			Match("catch"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CATCH", 11);
			LeaveRule("CATCH", 11);
			Leave_CATCH();
		}
	}
	// $ANTLR end "CATCH"

	partial void Enter_CHAR();
	partial void Leave_CHAR();

	// $ANTLR start "CHAR"
	[GrammarRule("CHAR")]
	private void mCHAR()
	{
		Enter_CHAR();
		EnterRule("CHAR", 12);
		TraceIn("CHAR", 12);
		try
		{
			int _type = CHAR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:99:6: ( 'char' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:99:8: 'char'
			{
			DebugLocation(99, 8);
			Match("char"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CHAR", 12);
			LeaveRule("CHAR", 12);
			Leave_CHAR();
		}
	}
	// $ANTLR end "CHAR"

	partial void Enter_CLASS();
	partial void Leave_CLASS();

	// $ANTLR start "CLASS"
	[GrammarRule("CLASS")]
	private void mCLASS()
	{
		Enter_CLASS();
		EnterRule("CLASS", 13);
		TraceIn("CLASS", 13);
		try
		{
			int _type = CLASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:100:7: ( 'class' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:100:9: 'class'
			{
			DebugLocation(100, 9);
			Match("class"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CLASS", 13);
			LeaveRule("CLASS", 13);
			Leave_CLASS();
		}
	}
	// $ANTLR end "CLASS"

	partial void Enter_COLON();
	partial void Leave_COLON();

	// $ANTLR start "COLON"
	[GrammarRule("COLON")]
	private void mCOLON()
	{
		Enter_COLON();
		EnterRule("COLON", 14);
		TraceIn("COLON", 14);
		try
		{
			int _type = COLON;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:101:7: ( ':' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:101:9: ':'
			{
			DebugLocation(101, 9);
			Match(':'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COLON", 14);
			LeaveRule("COLON", 14);
			Leave_COLON();
		}
	}
	// $ANTLR end "COLON"

	partial void Enter_COMMA();
	partial void Leave_COMMA();

	// $ANTLR start "COMMA"
	[GrammarRule("COMMA")]
	private void mCOMMA()
	{
		Enter_COMMA();
		EnterRule("COMMA", 15);
		TraceIn("COMMA", 15);
		try
		{
			int _type = COMMA;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:102:7: ( ',' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:102:9: ','
			{
			DebugLocation(102, 9);
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("COMMA", 15);
			LeaveRule("COMMA", 15);
			Leave_COMMA();
		}
	}
	// $ANTLR end "COMMA"

	partial void Enter_CONST();
	partial void Leave_CONST();

	// $ANTLR start "CONST"
	[GrammarRule("CONST")]
	private void mCONST()
	{
		Enter_CONST();
		EnterRule("CONST", 16);
		TraceIn("CONST", 16);
		try
		{
			int _type = CONST;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:103:7: ( 'const' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:103:9: 'const'
			{
			DebugLocation(103, 9);
			Match("const"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CONST", 16);
			LeaveRule("CONST", 16);
			Leave_CONST();
		}
	}
	// $ANTLR end "CONST"

	partial void Enter_CONTINUE();
	partial void Leave_CONTINUE();

	// $ANTLR start "CONTINUE"
	[GrammarRule("CONTINUE")]
	private void mCONTINUE()
	{
		Enter_CONTINUE();
		EnterRule("CONTINUE", 17);
		TraceIn("CONTINUE", 17);
		try
		{
			int _type = CONTINUE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:104:10: ( 'continue' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:104:12: 'continue'
			{
			DebugLocation(104, 12);
			Match("continue"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("CONTINUE", 17);
			LeaveRule("CONTINUE", 17);
			Leave_CONTINUE();
		}
	}
	// $ANTLR end "CONTINUE"

	partial void Enter_DEBUGGER();
	partial void Leave_DEBUGGER();

	// $ANTLR start "DEBUGGER"
	[GrammarRule("DEBUGGER")]
	private void mDEBUGGER()
	{
		Enter_DEBUGGER();
		EnterRule("DEBUGGER", 18);
		TraceIn("DEBUGGER", 18);
		try
		{
			int _type = DEBUGGER;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:105:10: ( 'debugger' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:105:12: 'debugger'
			{
			DebugLocation(105, 12);
			Match("debugger"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DEBUGGER", 18);
			LeaveRule("DEBUGGER", 18);
			Leave_DEBUGGER();
		}
	}
	// $ANTLR end "DEBUGGER"

	partial void Enter_DEC();
	partial void Leave_DEC();

	// $ANTLR start "DEC"
	[GrammarRule("DEC")]
	private void mDEC()
	{
		Enter_DEC();
		EnterRule("DEC", 19);
		TraceIn("DEC", 19);
		try
		{
			int _type = DEC;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:106:5: ( '--' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:106:7: '--'
			{
			DebugLocation(106, 7);
			Match("--"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DEC", 19);
			LeaveRule("DEC", 19);
			Leave_DEC();
		}
	}
	// $ANTLR end "DEC"

	partial void Enter_DEFAULT();
	partial void Leave_DEFAULT();

	// $ANTLR start "DEFAULT"
	[GrammarRule("DEFAULT")]
	private void mDEFAULT()
	{
		Enter_DEFAULT();
		EnterRule("DEFAULT", 20);
		TraceIn("DEFAULT", 20);
		try
		{
			int _type = DEFAULT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:107:9: ( 'default' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:107:11: 'default'
			{
			DebugLocation(107, 11);
			Match("default"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DEFAULT", 20);
			LeaveRule("DEFAULT", 20);
			Leave_DEFAULT();
		}
	}
	// $ANTLR end "DEFAULT"

	partial void Enter_DELETE();
	partial void Leave_DELETE();

	// $ANTLR start "DELETE"
	[GrammarRule("DELETE")]
	private void mDELETE()
	{
		Enter_DELETE();
		EnterRule("DELETE", 21);
		TraceIn("DELETE", 21);
		try
		{
			int _type = DELETE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:108:8: ( 'delete' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:108:10: 'delete'
			{
			DebugLocation(108, 10);
			Match("delete"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DELETE", 21);
			LeaveRule("DELETE", 21);
			Leave_DELETE();
		}
	}
	// $ANTLR end "DELETE"

	partial void Enter_DIV();
	partial void Leave_DIV();

	// $ANTLR start "DIV"
	[GrammarRule("DIV")]
	private void mDIV()
	{
		Enter_DIV();
		EnterRule("DIV", 22);
		TraceIn("DIV", 22);
		try
		{
			int _type = DIV;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:109:5: ( '/' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:109:7: '/'
			{
			DebugLocation(109, 7);
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DIV", 22);
			LeaveRule("DIV", 22);
			Leave_DIV();
		}
	}
	// $ANTLR end "DIV"

	partial void Enter_DIVASS();
	partial void Leave_DIVASS();

	// $ANTLR start "DIVASS"
	[GrammarRule("DIVASS")]
	private void mDIVASS()
	{
		Enter_DIVASS();
		EnterRule("DIVASS", 23);
		TraceIn("DIVASS", 23);
		try
		{
			int _type = DIVASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:110:8: ( '/=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:110:10: '/='
			{
			DebugLocation(110, 10);
			Match("/="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DIVASS", 23);
			LeaveRule("DIVASS", 23);
			Leave_DIVASS();
		}
	}
	// $ANTLR end "DIVASS"

	partial void Enter_DO();
	partial void Leave_DO();

	// $ANTLR start "DO"
	[GrammarRule("DO")]
	private void mDO()
	{
		Enter_DO();
		EnterRule("DO", 24);
		TraceIn("DO", 24);
		try
		{
			int _type = DO;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:111:4: ( 'do' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:111:6: 'do'
			{
			DebugLocation(111, 6);
			Match("do"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DO", 24);
			LeaveRule("DO", 24);
			Leave_DO();
		}
	}
	// $ANTLR end "DO"

	partial void Enter_DOT();
	partial void Leave_DOT();

	// $ANTLR start "DOT"
	[GrammarRule("DOT")]
	private void mDOT()
	{
		Enter_DOT();
		EnterRule("DOT", 25);
		TraceIn("DOT", 25);
		try
		{
			int _type = DOT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:112:5: ( '.' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:112:7: '.'
			{
			DebugLocation(112, 7);
			Match('.'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DOT", 25);
			LeaveRule("DOT", 25);
			Leave_DOT();
		}
	}
	// $ANTLR end "DOT"

	partial void Enter_DOUBLE();
	partial void Leave_DOUBLE();

	// $ANTLR start "DOUBLE"
	[GrammarRule("DOUBLE")]
	private void mDOUBLE()
	{
		Enter_DOUBLE();
		EnterRule("DOUBLE", 26);
		TraceIn("DOUBLE", 26);
		try
		{
			int _type = DOUBLE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:113:8: ( 'double' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:113:10: 'double'
			{
			DebugLocation(113, 10);
			Match("double"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DOUBLE", 26);
			LeaveRule("DOUBLE", 26);
			Leave_DOUBLE();
		}
	}
	// $ANTLR end "DOUBLE"

	partial void Enter_ELSE();
	partial void Leave_ELSE();

	// $ANTLR start "ELSE"
	[GrammarRule("ELSE")]
	private void mELSE()
	{
		Enter_ELSE();
		EnterRule("ELSE", 27);
		TraceIn("ELSE", 27);
		try
		{
			int _type = ELSE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:114:6: ( 'else' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:114:8: 'else'
			{
			DebugLocation(114, 8);
			Match("else"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ELSE", 27);
			LeaveRule("ELSE", 27);
			Leave_ELSE();
		}
	}
	// $ANTLR end "ELSE"

	partial void Enter_ENUM();
	partial void Leave_ENUM();

	// $ANTLR start "ENUM"
	[GrammarRule("ENUM")]
	private void mENUM()
	{
		Enter_ENUM();
		EnterRule("ENUM", 28);
		TraceIn("ENUM", 28);
		try
		{
			int _type = ENUM;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:115:6: ( 'enum' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:115:8: 'enum'
			{
			DebugLocation(115, 8);
			Match("enum"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ENUM", 28);
			LeaveRule("ENUM", 28);
			Leave_ENUM();
		}
	}
	// $ANTLR end "ENUM"

	partial void Enter_EQ();
	partial void Leave_EQ();

	// $ANTLR start "EQ"
	[GrammarRule("EQ")]
	private void mEQ()
	{
		Enter_EQ();
		EnterRule("EQ", 29);
		TraceIn("EQ", 29);
		try
		{
			int _type = EQ;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:116:4: ( '==' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:116:6: '=='
			{
			DebugLocation(116, 6);
			Match("=="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EQ", 29);
			LeaveRule("EQ", 29);
			Leave_EQ();
		}
	}
	// $ANTLR end "EQ"

	partial void Enter_EXPORT();
	partial void Leave_EXPORT();

	// $ANTLR start "EXPORT"
	[GrammarRule("EXPORT")]
	private void mEXPORT()
	{
		Enter_EXPORT();
		EnterRule("EXPORT", 30);
		TraceIn("EXPORT", 30);
		try
		{
			int _type = EXPORT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:117:8: ( 'export' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:117:10: 'export'
			{
			DebugLocation(117, 10);
			Match("export"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EXPORT", 30);
			LeaveRule("EXPORT", 30);
			Leave_EXPORT();
		}
	}
	// $ANTLR end "EXPORT"

	partial void Enter_EXTENDS();
	partial void Leave_EXTENDS();

	// $ANTLR start "EXTENDS"
	[GrammarRule("EXTENDS")]
	private void mEXTENDS()
	{
		Enter_EXTENDS();
		EnterRule("EXTENDS", 31);
		TraceIn("EXTENDS", 31);
		try
		{
			int _type = EXTENDS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:118:9: ( 'extends' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:118:11: 'extends'
			{
			DebugLocation(118, 11);
			Match("extends"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EXTENDS", 31);
			LeaveRule("EXTENDS", 31);
			Leave_EXTENDS();
		}
	}
	// $ANTLR end "EXTENDS"

	partial void Enter_FALSE();
	partial void Leave_FALSE();

	// $ANTLR start "FALSE"
	[GrammarRule("FALSE")]
	private void mFALSE()
	{
		Enter_FALSE();
		EnterRule("FALSE", 32);
		TraceIn("FALSE", 32);
		try
		{
			int _type = FALSE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:119:7: ( 'false' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:119:9: 'false'
			{
			DebugLocation(119, 9);
			Match("false"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FALSE", 32);
			LeaveRule("FALSE", 32);
			Leave_FALSE();
		}
	}
	// $ANTLR end "FALSE"

	partial void Enter_FINAL();
	partial void Leave_FINAL();

	// $ANTLR start "FINAL"
	[GrammarRule("FINAL")]
	private void mFINAL()
	{
		Enter_FINAL();
		EnterRule("FINAL", 33);
		TraceIn("FINAL", 33);
		try
		{
			int _type = FINAL;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:120:7: ( 'final' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:120:9: 'final'
			{
			DebugLocation(120, 9);
			Match("final"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FINAL", 33);
			LeaveRule("FINAL", 33);
			Leave_FINAL();
		}
	}
	// $ANTLR end "FINAL"

	partial void Enter_FINALLY();
	partial void Leave_FINALLY();

	// $ANTLR start "FINALLY"
	[GrammarRule("FINALLY")]
	private void mFINALLY()
	{
		Enter_FINALLY();
		EnterRule("FINALLY", 34);
		TraceIn("FINALLY", 34);
		try
		{
			int _type = FINALLY;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:121:9: ( 'finally' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:121:11: 'finally'
			{
			DebugLocation(121, 11);
			Match("finally"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FINALLY", 34);
			LeaveRule("FINALLY", 34);
			Leave_FINALLY();
		}
	}
	// $ANTLR end "FINALLY"

	partial void Enter_FLOAT();
	partial void Leave_FLOAT();

	// $ANTLR start "FLOAT"
	[GrammarRule("FLOAT")]
	private void mFLOAT()
	{
		Enter_FLOAT();
		EnterRule("FLOAT", 35);
		TraceIn("FLOAT", 35);
		try
		{
			int _type = FLOAT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:122:7: ( 'float' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:122:9: 'float'
			{
			DebugLocation(122, 9);
			Match("float"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FLOAT", 35);
			LeaveRule("FLOAT", 35);
			Leave_FLOAT();
		}
	}
	// $ANTLR end "FLOAT"

	partial void Enter_FOR();
	partial void Leave_FOR();

	// $ANTLR start "FOR"
	[GrammarRule("FOR")]
	private void mFOR()
	{
		Enter_FOR();
		EnterRule("FOR", 36);
		TraceIn("FOR", 36);
		try
		{
			int _type = FOR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:123:5: ( 'for' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:123:7: 'for'
			{
			DebugLocation(123, 7);
			Match("for"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FOR", 36);
			LeaveRule("FOR", 36);
			Leave_FOR();
		}
	}
	// $ANTLR end "FOR"

	partial void Enter_FUNCTION();
	partial void Leave_FUNCTION();

	// $ANTLR start "FUNCTION"
	[GrammarRule("FUNCTION")]
	private void mFUNCTION()
	{
		Enter_FUNCTION();
		EnterRule("FUNCTION", 37);
		TraceIn("FUNCTION", 37);
		try
		{
			int _type = FUNCTION;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:124:10: ( 'function' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:124:12: 'function'
			{
			DebugLocation(124, 12);
			Match("function"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("FUNCTION", 37);
			LeaveRule("FUNCTION", 37);
			Leave_FUNCTION();
		}
	}
	// $ANTLR end "FUNCTION"

	partial void Enter_GOTO();
	partial void Leave_GOTO();

	// $ANTLR start "GOTO"
	[GrammarRule("GOTO")]
	private void mGOTO()
	{
		Enter_GOTO();
		EnterRule("GOTO", 38);
		TraceIn("GOTO", 38);
		try
		{
			int _type = GOTO;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:125:6: ( 'goto' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:125:8: 'goto'
			{
			DebugLocation(125, 8);
			Match("goto"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GOTO", 38);
			LeaveRule("GOTO", 38);
			Leave_GOTO();
		}
	}
	// $ANTLR end "GOTO"

	partial void Enter_GT();
	partial void Leave_GT();

	// $ANTLR start "GT"
	[GrammarRule("GT")]
	private void mGT()
	{
		Enter_GT();
		EnterRule("GT", 39);
		TraceIn("GT", 39);
		try
		{
			int _type = GT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:126:4: ( '>' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:126:6: '>'
			{
			DebugLocation(126, 6);
			Match('>'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GT", 39);
			LeaveRule("GT", 39);
			Leave_GT();
		}
	}
	// $ANTLR end "GT"

	partial void Enter_GTE();
	partial void Leave_GTE();

	// $ANTLR start "GTE"
	[GrammarRule("GTE")]
	private void mGTE()
	{
		Enter_GTE();
		EnterRule("GTE", 40);
		TraceIn("GTE", 40);
		try
		{
			int _type = GTE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:127:5: ( '>=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:127:7: '>='
			{
			DebugLocation(127, 7);
			Match(">="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("GTE", 40);
			LeaveRule("GTE", 40);
			Leave_GTE();
		}
	}
	// $ANTLR end "GTE"

	partial void Enter_IF();
	partial void Leave_IF();

	// $ANTLR start "IF"
	[GrammarRule("IF")]
	private void mIF()
	{
		Enter_IF();
		EnterRule("IF", 41);
		TraceIn("IF", 41);
		try
		{
			int _type = IF;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:128:4: ( 'if' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:128:6: 'if'
			{
			DebugLocation(128, 6);
			Match("if"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IF", 41);
			LeaveRule("IF", 41);
			Leave_IF();
		}
	}
	// $ANTLR end "IF"

	partial void Enter_IMPLEMENTS();
	partial void Leave_IMPLEMENTS();

	// $ANTLR start "IMPLEMENTS"
	[GrammarRule("IMPLEMENTS")]
	private void mIMPLEMENTS()
	{
		Enter_IMPLEMENTS();
		EnterRule("IMPLEMENTS", 42);
		TraceIn("IMPLEMENTS", 42);
		try
		{
			int _type = IMPLEMENTS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:129:12: ( 'implements' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:129:14: 'implements'
			{
			DebugLocation(129, 14);
			Match("implements"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IMPLEMENTS", 42);
			LeaveRule("IMPLEMENTS", 42);
			Leave_IMPLEMENTS();
		}
	}
	// $ANTLR end "IMPLEMENTS"

	partial void Enter_IMPORT();
	partial void Leave_IMPORT();

	// $ANTLR start "IMPORT"
	[GrammarRule("IMPORT")]
	private void mIMPORT()
	{
		Enter_IMPORT();
		EnterRule("IMPORT", 43);
		TraceIn("IMPORT", 43);
		try
		{
			int _type = IMPORT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:130:8: ( 'import' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:130:10: 'import'
			{
			DebugLocation(130, 10);
			Match("import"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IMPORT", 43);
			LeaveRule("IMPORT", 43);
			Leave_IMPORT();
		}
	}
	// $ANTLR end "IMPORT"

	partial void Enter_IN();
	partial void Leave_IN();

	// $ANTLR start "IN"
	[GrammarRule("IN")]
	private void mIN()
	{
		Enter_IN();
		EnterRule("IN", 44);
		TraceIn("IN", 44);
		try
		{
			int _type = IN;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:131:4: ( 'in' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:131:6: 'in'
			{
			DebugLocation(131, 6);
			Match("in"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("IN", 44);
			LeaveRule("IN", 44);
			Leave_IN();
		}
	}
	// $ANTLR end "IN"

	partial void Enter_INC();
	partial void Leave_INC();

	// $ANTLR start "INC"
	[GrammarRule("INC")]
	private void mINC()
	{
		Enter_INC();
		EnterRule("INC", 45);
		TraceIn("INC", 45);
		try
		{
			int _type = INC;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:132:5: ( '++' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:132:7: '++'
			{
			DebugLocation(132, 7);
			Match("++"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INC", 45);
			LeaveRule("INC", 45);
			Leave_INC();
		}
	}
	// $ANTLR end "INC"

	partial void Enter_INSTANCEOF();
	partial void Leave_INSTANCEOF();

	// $ANTLR start "INSTANCEOF"
	[GrammarRule("INSTANCEOF")]
	private void mINSTANCEOF()
	{
		Enter_INSTANCEOF();
		EnterRule("INSTANCEOF", 46);
		TraceIn("INSTANCEOF", 46);
		try
		{
			int _type = INSTANCEOF;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:133:12: ( 'instanceof' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:133:14: 'instanceof'
			{
			DebugLocation(133, 14);
			Match("instanceof"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INSTANCEOF", 46);
			LeaveRule("INSTANCEOF", 46);
			Leave_INSTANCEOF();
		}
	}
	// $ANTLR end "INSTANCEOF"

	partial void Enter_INT();
	partial void Leave_INT();

	// $ANTLR start "INT"
	[GrammarRule("INT")]
	private void mINT()
	{
		Enter_INT();
		EnterRule("INT", 47);
		TraceIn("INT", 47);
		try
		{
			int _type = INT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:134:5: ( 'int' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:134:7: 'int'
			{
			DebugLocation(134, 7);
			Match("int"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INT", 47);
			LeaveRule("INT", 47);
			Leave_INT();
		}
	}
	// $ANTLR end "INT"

	partial void Enter_INTERFACE();
	partial void Leave_INTERFACE();

	// $ANTLR start "INTERFACE"
	[GrammarRule("INTERFACE")]
	private void mINTERFACE()
	{
		Enter_INTERFACE();
		EnterRule("INTERFACE", 48);
		TraceIn("INTERFACE", 48);
		try
		{
			int _type = INTERFACE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:135:11: ( 'interface' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:135:13: 'interface'
			{
			DebugLocation(135, 13);
			Match("interface"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INTERFACE", 48);
			LeaveRule("INTERFACE", 48);
			Leave_INTERFACE();
		}
	}
	// $ANTLR end "INTERFACE"

	partial void Enter_INV();
	partial void Leave_INV();

	// $ANTLR start "INV"
	[GrammarRule("INV")]
	private void mINV()
	{
		Enter_INV();
		EnterRule("INV", 49);
		TraceIn("INV", 49);
		try
		{
			int _type = INV;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:136:5: ( '~' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:136:7: '~'
			{
			DebugLocation(136, 7);
			Match('~'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("INV", 49);
			LeaveRule("INV", 49);
			Leave_INV();
		}
	}
	// $ANTLR end "INV"

	partial void Enter_LAND();
	partial void Leave_LAND();

	// $ANTLR start "LAND"
	[GrammarRule("LAND")]
	private void mLAND()
	{
		Enter_LAND();
		EnterRule("LAND", 50);
		TraceIn("LAND", 50);
		try
		{
			int _type = LAND;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:137:6: ( '&&' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:137:8: '&&'
			{
			DebugLocation(137, 8);
			Match("&&"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LAND", 50);
			LeaveRule("LAND", 50);
			Leave_LAND();
		}
	}
	// $ANTLR end "LAND"

	partial void Enter_LBRACE();
	partial void Leave_LBRACE();

	// $ANTLR start "LBRACE"
	[GrammarRule("LBRACE")]
	private void mLBRACE()
	{
		Enter_LBRACE();
		EnterRule("LBRACE", 51);
		TraceIn("LBRACE", 51);
		try
		{
			int _type = LBRACE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:138:8: ( '{' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:138:10: '{'
			{
			DebugLocation(138, 10);
			Match('{'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LBRACE", 51);
			LeaveRule("LBRACE", 51);
			Leave_LBRACE();
		}
	}
	// $ANTLR end "LBRACE"

	partial void Enter_LBRACK();
	partial void Leave_LBRACK();

	// $ANTLR start "LBRACK"
	[GrammarRule("LBRACK")]
	private void mLBRACK()
	{
		Enter_LBRACK();
		EnterRule("LBRACK", 52);
		TraceIn("LBRACK", 52);
		try
		{
			int _type = LBRACK;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:139:8: ( '[' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:139:10: '['
			{
			DebugLocation(139, 10);
			Match('['); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LBRACK", 52);
			LeaveRule("LBRACK", 52);
			Leave_LBRACK();
		}
	}
	// $ANTLR end "LBRACK"

	partial void Enter_LONG();
	partial void Leave_LONG();

	// $ANTLR start "LONG"
	[GrammarRule("LONG")]
	private void mLONG()
	{
		Enter_LONG();
		EnterRule("LONG", 53);
		TraceIn("LONG", 53);
		try
		{
			int _type = LONG;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:140:6: ( 'long' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:140:8: 'long'
			{
			DebugLocation(140, 8);
			Match("long"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LONG", 53);
			LeaveRule("LONG", 53);
			Leave_LONG();
		}
	}
	// $ANTLR end "LONG"

	partial void Enter_LOR();
	partial void Leave_LOR();

	// $ANTLR start "LOR"
	[GrammarRule("LOR")]
	private void mLOR()
	{
		Enter_LOR();
		EnterRule("LOR", 54);
		TraceIn("LOR", 54);
		try
		{
			int _type = LOR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:141:5: ( '||' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:141:7: '||'
			{
			DebugLocation(141, 7);
			Match("||"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LOR", 54);
			LeaveRule("LOR", 54);
			Leave_LOR();
		}
	}
	// $ANTLR end "LOR"

	partial void Enter_LPAREN();
	partial void Leave_LPAREN();

	// $ANTLR start "LPAREN"
	[GrammarRule("LPAREN")]
	private void mLPAREN()
	{
		Enter_LPAREN();
		EnterRule("LPAREN", 55);
		TraceIn("LPAREN", 55);
		try
		{
			int _type = LPAREN;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:142:8: ( '(' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:142:10: '('
			{
			DebugLocation(142, 10);
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LPAREN", 55);
			LeaveRule("LPAREN", 55);
			Leave_LPAREN();
		}
	}
	// $ANTLR end "LPAREN"

	partial void Enter_LT();
	partial void Leave_LT();

	// $ANTLR start "LT"
	[GrammarRule("LT")]
	private void mLT()
	{
		Enter_LT();
		EnterRule("LT", 56);
		TraceIn("LT", 56);
		try
		{
			int _type = LT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:143:4: ( '<' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:143:6: '<'
			{
			DebugLocation(143, 6);
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LT", 56);
			LeaveRule("LT", 56);
			Leave_LT();
		}
	}
	// $ANTLR end "LT"

	partial void Enter_LTE();
	partial void Leave_LTE();

	// $ANTLR start "LTE"
	[GrammarRule("LTE")]
	private void mLTE()
	{
		Enter_LTE();
		EnterRule("LTE", 57);
		TraceIn("LTE", 57);
		try
		{
			int _type = LTE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:144:5: ( '<=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:144:7: '<='
			{
			DebugLocation(144, 7);
			Match("<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("LTE", 57);
			LeaveRule("LTE", 57);
			Leave_LTE();
		}
	}
	// $ANTLR end "LTE"

	partial void Enter_MOD();
	partial void Leave_MOD();

	// $ANTLR start "MOD"
	[GrammarRule("MOD")]
	private void mMOD()
	{
		Enter_MOD();
		EnterRule("MOD", 58);
		TraceIn("MOD", 58);
		try
		{
			int _type = MOD;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:145:5: ( '%' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:145:7: '%'
			{
			DebugLocation(145, 7);
			Match('%'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MOD", 58);
			LeaveRule("MOD", 58);
			Leave_MOD();
		}
	}
	// $ANTLR end "MOD"

	partial void Enter_MODASS();
	partial void Leave_MODASS();

	// $ANTLR start "MODASS"
	[GrammarRule("MODASS")]
	private void mMODASS()
	{
		Enter_MODASS();
		EnterRule("MODASS", 59);
		TraceIn("MODASS", 59);
		try
		{
			int _type = MODASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:146:8: ( '%=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:146:10: '%='
			{
			DebugLocation(146, 10);
			Match("%="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MODASS", 59);
			LeaveRule("MODASS", 59);
			Leave_MODASS();
		}
	}
	// $ANTLR end "MODASS"

	partial void Enter_MUL();
	partial void Leave_MUL();

	// $ANTLR start "MUL"
	[GrammarRule("MUL")]
	private void mMUL()
	{
		Enter_MUL();
		EnterRule("MUL", 60);
		TraceIn("MUL", 60);
		try
		{
			int _type = MUL;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:147:5: ( '*' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:147:7: '*'
			{
			DebugLocation(147, 7);
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MUL", 60);
			LeaveRule("MUL", 60);
			Leave_MUL();
		}
	}
	// $ANTLR end "MUL"

	partial void Enter_MULASS();
	partial void Leave_MULASS();

	// $ANTLR start "MULASS"
	[GrammarRule("MULASS")]
	private void mMULASS()
	{
		Enter_MULASS();
		EnterRule("MULASS", 61);
		TraceIn("MULASS", 61);
		try
		{
			int _type = MULASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:148:8: ( '*=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:148:10: '*='
			{
			DebugLocation(148, 10);
			Match("*="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MULASS", 61);
			LeaveRule("MULASS", 61);
			Leave_MULASS();
		}
	}
	// $ANTLR end "MULASS"

	partial void Enter_NATIVE();
	partial void Leave_NATIVE();

	// $ANTLR start "NATIVE"
	[GrammarRule("NATIVE")]
	private void mNATIVE()
	{
		Enter_NATIVE();
		EnterRule("NATIVE", 62);
		TraceIn("NATIVE", 62);
		try
		{
			int _type = NATIVE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:149:8: ( 'native' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:149:10: 'native'
			{
			DebugLocation(149, 10);
			Match("native"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NATIVE", 62);
			LeaveRule("NATIVE", 62);
			Leave_NATIVE();
		}
	}
	// $ANTLR end "NATIVE"

	partial void Enter_NEQ();
	partial void Leave_NEQ();

	// $ANTLR start "NEQ"
	[GrammarRule("NEQ")]
	private void mNEQ()
	{
		Enter_NEQ();
		EnterRule("NEQ", 63);
		TraceIn("NEQ", 63);
		try
		{
			int _type = NEQ;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:150:5: ( '!=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:150:7: '!='
			{
			DebugLocation(150, 7);
			Match("!="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NEQ", 63);
			LeaveRule("NEQ", 63);
			Leave_NEQ();
		}
	}
	// $ANTLR end "NEQ"

	partial void Enter_NEW();
	partial void Leave_NEW();

	// $ANTLR start "NEW"
	[GrammarRule("NEW")]
	private void mNEW()
	{
		Enter_NEW();
		EnterRule("NEW", 64);
		TraceIn("NEW", 64);
		try
		{
			int _type = NEW;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:151:5: ( 'new' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:151:7: 'new'
			{
			DebugLocation(151, 7);
			Match("new"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NEW", 64);
			LeaveRule("NEW", 64);
			Leave_NEW();
		}
	}
	// $ANTLR end "NEW"

	partial void Enter_NOT();
	partial void Leave_NOT();

	// $ANTLR start "NOT"
	[GrammarRule("NOT")]
	private void mNOT()
	{
		Enter_NOT();
		EnterRule("NOT", 65);
		TraceIn("NOT", 65);
		try
		{
			int _type = NOT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:152:5: ( '!' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:152:7: '!'
			{
			DebugLocation(152, 7);
			Match('!'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NOT", 65);
			LeaveRule("NOT", 65);
			Leave_NOT();
		}
	}
	// $ANTLR end "NOT"

	partial void Enter_NSAME();
	partial void Leave_NSAME();

	// $ANTLR start "NSAME"
	[GrammarRule("NSAME")]
	private void mNSAME()
	{
		Enter_NSAME();
		EnterRule("NSAME", 66);
		TraceIn("NSAME", 66);
		try
		{
			int _type = NSAME;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:153:7: ( '!==' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:153:9: '!=='
			{
			DebugLocation(153, 9);
			Match("!=="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NSAME", 66);
			LeaveRule("NSAME", 66);
			Leave_NSAME();
		}
	}
	// $ANTLR end "NSAME"

	partial void Enter_NULL();
	partial void Leave_NULL();

	// $ANTLR start "NULL"
	[GrammarRule("NULL")]
	private void mNULL()
	{
		Enter_NULL();
		EnterRule("NULL", 67);
		TraceIn("NULL", 67);
		try
		{
			int _type = NULL;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:154:6: ( 'null' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:154:8: 'null'
			{
			DebugLocation(154, 8);
			Match("null"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("NULL", 67);
			LeaveRule("NULL", 67);
			Leave_NULL();
		}
	}
	// $ANTLR end "NULL"

	partial void Enter_OR();
	partial void Leave_OR();

	// $ANTLR start "OR"
	[GrammarRule("OR")]
	private void mOR()
	{
		Enter_OR();
		EnterRule("OR", 68);
		TraceIn("OR", 68);
		try
		{
			int _type = OR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:155:4: ( '|' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:155:6: '|'
			{
			DebugLocation(155, 6);
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OR", 68);
			LeaveRule("OR", 68);
			Leave_OR();
		}
	}
	// $ANTLR end "OR"

	partial void Enter_ORASS();
	partial void Leave_ORASS();

	// $ANTLR start "ORASS"
	[GrammarRule("ORASS")]
	private void mORASS()
	{
		Enter_ORASS();
		EnterRule("ORASS", 69);
		TraceIn("ORASS", 69);
		try
		{
			int _type = ORASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:156:7: ( '|=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:156:9: '|='
			{
			DebugLocation(156, 9);
			Match("|="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("ORASS", 69);
			LeaveRule("ORASS", 69);
			Leave_ORASS();
		}
	}
	// $ANTLR end "ORASS"

	partial void Enter_PACKAGE();
	partial void Leave_PACKAGE();

	// $ANTLR start "PACKAGE"
	[GrammarRule("PACKAGE")]
	private void mPACKAGE()
	{
		Enter_PACKAGE();
		EnterRule("PACKAGE", 70);
		TraceIn("PACKAGE", 70);
		try
		{
			int _type = PACKAGE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:157:9: ( 'package' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:157:11: 'package'
			{
			DebugLocation(157, 11);
			Match("package"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PACKAGE", 70);
			LeaveRule("PACKAGE", 70);
			Leave_PACKAGE();
		}
	}
	// $ANTLR end "PACKAGE"

	partial void Enter_PRIVATE();
	partial void Leave_PRIVATE();

	// $ANTLR start "PRIVATE"
	[GrammarRule("PRIVATE")]
	private void mPRIVATE()
	{
		Enter_PRIVATE();
		EnterRule("PRIVATE", 71);
		TraceIn("PRIVATE", 71);
		try
		{
			int _type = PRIVATE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:158:9: ( 'private' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:158:11: 'private'
			{
			DebugLocation(158, 11);
			Match("private"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PRIVATE", 71);
			LeaveRule("PRIVATE", 71);
			Leave_PRIVATE();
		}
	}
	// $ANTLR end "PRIVATE"

	partial void Enter_PROTECTED();
	partial void Leave_PROTECTED();

	// $ANTLR start "PROTECTED"
	[GrammarRule("PROTECTED")]
	private void mPROTECTED()
	{
		Enter_PROTECTED();
		EnterRule("PROTECTED", 72);
		TraceIn("PROTECTED", 72);
		try
		{
			int _type = PROTECTED;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:159:11: ( 'protected' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:159:13: 'protected'
			{
			DebugLocation(159, 13);
			Match("protected"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PROTECTED", 72);
			LeaveRule("PROTECTED", 72);
			Leave_PROTECTED();
		}
	}
	// $ANTLR end "PROTECTED"

	partial void Enter_PUBLIC();
	partial void Leave_PUBLIC();

	// $ANTLR start "PUBLIC"
	[GrammarRule("PUBLIC")]
	private void mPUBLIC()
	{
		Enter_PUBLIC();
		EnterRule("PUBLIC", 73);
		TraceIn("PUBLIC", 73);
		try
		{
			int _type = PUBLIC;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:160:8: ( 'public' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:160:10: 'public'
			{
			DebugLocation(160, 10);
			Match("public"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("PUBLIC", 73);
			LeaveRule("PUBLIC", 73);
			Leave_PUBLIC();
		}
	}
	// $ANTLR end "PUBLIC"

	partial void Enter_QUE();
	partial void Leave_QUE();

	// $ANTLR start "QUE"
	[GrammarRule("QUE")]
	private void mQUE()
	{
		Enter_QUE();
		EnterRule("QUE", 74);
		TraceIn("QUE", 74);
		try
		{
			int _type = QUE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:161:5: ( '?' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:161:7: '?'
			{
			DebugLocation(161, 7);
			Match('?'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("QUE", 74);
			LeaveRule("QUE", 74);
			Leave_QUE();
		}
	}
	// $ANTLR end "QUE"

	partial void Enter_RBRACE();
	partial void Leave_RBRACE();

	// $ANTLR start "RBRACE"
	[GrammarRule("RBRACE")]
	private void mRBRACE()
	{
		Enter_RBRACE();
		EnterRule("RBRACE", 75);
		TraceIn("RBRACE", 75);
		try
		{
			int _type = RBRACE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:162:8: ( '}' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:162:10: '}'
			{
			DebugLocation(162, 10);
			Match('}'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RBRACE", 75);
			LeaveRule("RBRACE", 75);
			Leave_RBRACE();
		}
	}
	// $ANTLR end "RBRACE"

	partial void Enter_RBRACK();
	partial void Leave_RBRACK();

	// $ANTLR start "RBRACK"
	[GrammarRule("RBRACK")]
	private void mRBRACK()
	{
		Enter_RBRACK();
		EnterRule("RBRACK", 76);
		TraceIn("RBRACK", 76);
		try
		{
			int _type = RBRACK;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:163:8: ( ']' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:163:10: ']'
			{
			DebugLocation(163, 10);
			Match(']'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RBRACK", 76);
			LeaveRule("RBRACK", 76);
			Leave_RBRACK();
		}
	}
	// $ANTLR end "RBRACK"

	partial void Enter_RETURN();
	partial void Leave_RETURN();

	// $ANTLR start "RETURN"
	[GrammarRule("RETURN")]
	private void mRETURN()
	{
		Enter_RETURN();
		EnterRule("RETURN", 77);
		TraceIn("RETURN", 77);
		try
		{
			int _type = RETURN;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:164:8: ( 'return' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:164:10: 'return'
			{
			DebugLocation(164, 10);
			Match("return"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RETURN", 77);
			LeaveRule("RETURN", 77);
			Leave_RETURN();
		}
	}
	// $ANTLR end "RETURN"

	partial void Enter_RPAREN();
	partial void Leave_RPAREN();

	// $ANTLR start "RPAREN"
	[GrammarRule("RPAREN")]
	private void mRPAREN()
	{
		Enter_RPAREN();
		EnterRule("RPAREN", 78);
		TraceIn("RPAREN", 78);
		try
		{
			int _type = RPAREN;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:165:8: ( ')' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:165:10: ')'
			{
			DebugLocation(165, 10);
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RPAREN", 78);
			LeaveRule("RPAREN", 78);
			Leave_RPAREN();
		}
	}
	// $ANTLR end "RPAREN"

	partial void Enter_SAME();
	partial void Leave_SAME();

	// $ANTLR start "SAME"
	[GrammarRule("SAME")]
	private void mSAME()
	{
		Enter_SAME();
		EnterRule("SAME", 79);
		TraceIn("SAME", 79);
		try
		{
			int _type = SAME;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:166:6: ( '===' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:166:8: '==='
			{
			DebugLocation(166, 8);
			Match("==="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SAME", 79);
			LeaveRule("SAME", 79);
			Leave_SAME();
		}
	}
	// $ANTLR end "SAME"

	partial void Enter_SEMIC();
	partial void Leave_SEMIC();

	// $ANTLR start "SEMIC"
	[GrammarRule("SEMIC")]
	private void mSEMIC()
	{
		Enter_SEMIC();
		EnterRule("SEMIC", 80);
		TraceIn("SEMIC", 80);
		try
		{
			int _type = SEMIC;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:167:7: ( ';' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:167:9: ';'
			{
			DebugLocation(167, 9);
			Match(';'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SEMIC", 80);
			LeaveRule("SEMIC", 80);
			Leave_SEMIC();
		}
	}
	// $ANTLR end "SEMIC"

	partial void Enter_SHL();
	partial void Leave_SHL();

	// $ANTLR start "SHL"
	[GrammarRule("SHL")]
	private void mSHL()
	{
		Enter_SHL();
		EnterRule("SHL", 81);
		TraceIn("SHL", 81);
		try
		{
			int _type = SHL;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:168:5: ( '<<' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:168:7: '<<'
			{
			DebugLocation(168, 7);
			Match("<<"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHL", 81);
			LeaveRule("SHL", 81);
			Leave_SHL();
		}
	}
	// $ANTLR end "SHL"

	partial void Enter_SHLASS();
	partial void Leave_SHLASS();

	// $ANTLR start "SHLASS"
	[GrammarRule("SHLASS")]
	private void mSHLASS()
	{
		Enter_SHLASS();
		EnterRule("SHLASS", 82);
		TraceIn("SHLASS", 82);
		try
		{
			int _type = SHLASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:169:8: ( '<<=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:169:10: '<<='
			{
			DebugLocation(169, 10);
			Match("<<="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHLASS", 82);
			LeaveRule("SHLASS", 82);
			Leave_SHLASS();
		}
	}
	// $ANTLR end "SHLASS"

	partial void Enter_SHORT();
	partial void Leave_SHORT();

	// $ANTLR start "SHORT"
	[GrammarRule("SHORT")]
	private void mSHORT()
	{
		Enter_SHORT();
		EnterRule("SHORT", 83);
		TraceIn("SHORT", 83);
		try
		{
			int _type = SHORT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:170:7: ( 'short' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:170:9: 'short'
			{
			DebugLocation(170, 9);
			Match("short"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHORT", 83);
			LeaveRule("SHORT", 83);
			Leave_SHORT();
		}
	}
	// $ANTLR end "SHORT"

	partial void Enter_SHR();
	partial void Leave_SHR();

	// $ANTLR start "SHR"
	[GrammarRule("SHR")]
	private void mSHR()
	{
		Enter_SHR();
		EnterRule("SHR", 84);
		TraceIn("SHR", 84);
		try
		{
			int _type = SHR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:171:5: ( '>>' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:171:7: '>>'
			{
			DebugLocation(171, 7);
			Match(">>"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHR", 84);
			LeaveRule("SHR", 84);
			Leave_SHR();
		}
	}
	// $ANTLR end "SHR"

	partial void Enter_SHRASS();
	partial void Leave_SHRASS();

	// $ANTLR start "SHRASS"
	[GrammarRule("SHRASS")]
	private void mSHRASS()
	{
		Enter_SHRASS();
		EnterRule("SHRASS", 85);
		TraceIn("SHRASS", 85);
		try
		{
			int _type = SHRASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:172:8: ( '>>=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:172:10: '>>='
			{
			DebugLocation(172, 10);
			Match(">>="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHRASS", 85);
			LeaveRule("SHRASS", 85);
			Leave_SHRASS();
		}
	}
	// $ANTLR end "SHRASS"

	partial void Enter_SHU();
	partial void Leave_SHU();

	// $ANTLR start "SHU"
	[GrammarRule("SHU")]
	private void mSHU()
	{
		Enter_SHU();
		EnterRule("SHU", 86);
		TraceIn("SHU", 86);
		try
		{
			int _type = SHU;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:173:5: ( '>>>' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:173:7: '>>>'
			{
			DebugLocation(173, 7);
			Match(">>>"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHU", 86);
			LeaveRule("SHU", 86);
			Leave_SHU();
		}
	}
	// $ANTLR end "SHU"

	partial void Enter_SHUASS();
	partial void Leave_SHUASS();

	// $ANTLR start "SHUASS"
	[GrammarRule("SHUASS")]
	private void mSHUASS()
	{
		Enter_SHUASS();
		EnterRule("SHUASS", 87);
		TraceIn("SHUASS", 87);
		try
		{
			int _type = SHUASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:174:8: ( '>>>=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:174:10: '>>>='
			{
			DebugLocation(174, 10);
			Match(">>>="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SHUASS", 87);
			LeaveRule("SHUASS", 87);
			Leave_SHUASS();
		}
	}
	// $ANTLR end "SHUASS"

	partial void Enter_STATIC();
	partial void Leave_STATIC();

	// $ANTLR start "STATIC"
	[GrammarRule("STATIC")]
	private void mSTATIC()
	{
		Enter_STATIC();
		EnterRule("STATIC", 88);
		TraceIn("STATIC", 88);
		try
		{
			int _type = STATIC;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:175:8: ( 'static' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:175:10: 'static'
			{
			DebugLocation(175, 10);
			Match("static"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("STATIC", 88);
			LeaveRule("STATIC", 88);
			Leave_STATIC();
		}
	}
	// $ANTLR end "STATIC"

	partial void Enter_SUB();
	partial void Leave_SUB();

	// $ANTLR start "SUB"
	[GrammarRule("SUB")]
	private void mSUB()
	{
		Enter_SUB();
		EnterRule("SUB", 89);
		TraceIn("SUB", 89);
		try
		{
			int _type = SUB;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:176:5: ( '-' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:176:7: '-'
			{
			DebugLocation(176, 7);
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUB", 89);
			LeaveRule("SUB", 89);
			Leave_SUB();
		}
	}
	// $ANTLR end "SUB"

	partial void Enter_SUBASS();
	partial void Leave_SUBASS();

	// $ANTLR start "SUBASS"
	[GrammarRule("SUBASS")]
	private void mSUBASS()
	{
		Enter_SUBASS();
		EnterRule("SUBASS", 90);
		TraceIn("SUBASS", 90);
		try
		{
			int _type = SUBASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:177:8: ( '-=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:177:10: '-='
			{
			DebugLocation(177, 10);
			Match("-="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUBASS", 90);
			LeaveRule("SUBASS", 90);
			Leave_SUBASS();
		}
	}
	// $ANTLR end "SUBASS"

	partial void Enter_SUPER();
	partial void Leave_SUPER();

	// $ANTLR start "SUPER"
	[GrammarRule("SUPER")]
	private void mSUPER()
	{
		Enter_SUPER();
		EnterRule("SUPER", 91);
		TraceIn("SUPER", 91);
		try
		{
			int _type = SUPER;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:178:7: ( 'super' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:178:9: 'super'
			{
			DebugLocation(178, 9);
			Match("super"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SUPER", 91);
			LeaveRule("SUPER", 91);
			Leave_SUPER();
		}
	}
	// $ANTLR end "SUPER"

	partial void Enter_SWITCH();
	partial void Leave_SWITCH();

	// $ANTLR start "SWITCH"
	[GrammarRule("SWITCH")]
	private void mSWITCH()
	{
		Enter_SWITCH();
		EnterRule("SWITCH", 92);
		TraceIn("SWITCH", 92);
		try
		{
			int _type = SWITCH;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:179:8: ( 'switch' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:179:10: 'switch'
			{
			DebugLocation(179, 10);
			Match("switch"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SWITCH", 92);
			LeaveRule("SWITCH", 92);
			Leave_SWITCH();
		}
	}
	// $ANTLR end "SWITCH"

	partial void Enter_SYNCHRONIZED();
	partial void Leave_SYNCHRONIZED();

	// $ANTLR start "SYNCHRONIZED"
	[GrammarRule("SYNCHRONIZED")]
	private void mSYNCHRONIZED()
	{
		Enter_SYNCHRONIZED();
		EnterRule("SYNCHRONIZED", 93);
		TraceIn("SYNCHRONIZED", 93);
		try
		{
			int _type = SYNCHRONIZED;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:180:14: ( 'synchronized' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:180:16: 'synchronized'
			{
			DebugLocation(180, 16);
			Match("synchronized"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SYNCHRONIZED", 93);
			LeaveRule("SYNCHRONIZED", 93);
			Leave_SYNCHRONIZED();
		}
	}
	// $ANTLR end "SYNCHRONIZED"

	partial void Enter_THIS();
	partial void Leave_THIS();

	// $ANTLR start "THIS"
	[GrammarRule("THIS")]
	private void mTHIS()
	{
		Enter_THIS();
		EnterRule("THIS", 94);
		TraceIn("THIS", 94);
		try
		{
			int _type = THIS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:181:6: ( 'this' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:181:8: 'this'
			{
			DebugLocation(181, 8);
			Match("this"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("THIS", 94);
			LeaveRule("THIS", 94);
			Leave_THIS();
		}
	}
	// $ANTLR end "THIS"

	partial void Enter_THROW();
	partial void Leave_THROW();

	// $ANTLR start "THROW"
	[GrammarRule("THROW")]
	private void mTHROW()
	{
		Enter_THROW();
		EnterRule("THROW", 95);
		TraceIn("THROW", 95);
		try
		{
			int _type = THROW;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:182:7: ( 'throw' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:182:9: 'throw'
			{
			DebugLocation(182, 9);
			Match("throw"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("THROW", 95);
			LeaveRule("THROW", 95);
			Leave_THROW();
		}
	}
	// $ANTLR end "THROW"

	partial void Enter_THROWS();
	partial void Leave_THROWS();

	// $ANTLR start "THROWS"
	[GrammarRule("THROWS")]
	private void mTHROWS()
	{
		Enter_THROWS();
		EnterRule("THROWS", 96);
		TraceIn("THROWS", 96);
		try
		{
			int _type = THROWS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:183:8: ( 'throws' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:183:10: 'throws'
			{
			DebugLocation(183, 10);
			Match("throws"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("THROWS", 96);
			LeaveRule("THROWS", 96);
			Leave_THROWS();
		}
	}
	// $ANTLR end "THROWS"

	partial void Enter_TRANSIENT();
	partial void Leave_TRANSIENT();

	// $ANTLR start "TRANSIENT"
	[GrammarRule("TRANSIENT")]
	private void mTRANSIENT()
	{
		Enter_TRANSIENT();
		EnterRule("TRANSIENT", 97);
		TraceIn("TRANSIENT", 97);
		try
		{
			int _type = TRANSIENT;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:184:11: ( 'transient' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:184:13: 'transient'
			{
			DebugLocation(184, 13);
			Match("transient"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TRANSIENT", 97);
			LeaveRule("TRANSIENT", 97);
			Leave_TRANSIENT();
		}
	}
	// $ANTLR end "TRANSIENT"

	partial void Enter_TRUE();
	partial void Leave_TRUE();

	// $ANTLR start "TRUE"
	[GrammarRule("TRUE")]
	private void mTRUE()
	{
		Enter_TRUE();
		EnterRule("TRUE", 98);
		TraceIn("TRUE", 98);
		try
		{
			int _type = TRUE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:185:6: ( 'true' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:185:8: 'true'
			{
			DebugLocation(185, 8);
			Match("true"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TRUE", 98);
			LeaveRule("TRUE", 98);
			Leave_TRUE();
		}
	}
	// $ANTLR end "TRUE"

	partial void Enter_TRY();
	partial void Leave_TRY();

	// $ANTLR start "TRY"
	[GrammarRule("TRY")]
	private void mTRY()
	{
		Enter_TRY();
		EnterRule("TRY", 99);
		TraceIn("TRY", 99);
		try
		{
			int _type = TRY;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:186:5: ( 'try' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:186:7: 'try'
			{
			DebugLocation(186, 7);
			Match("try"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TRY", 99);
			LeaveRule("TRY", 99);
			Leave_TRY();
		}
	}
	// $ANTLR end "TRY"

	partial void Enter_TYPEOF();
	partial void Leave_TYPEOF();

	// $ANTLR start "TYPEOF"
	[GrammarRule("TYPEOF")]
	private void mTYPEOF()
	{
		Enter_TYPEOF();
		EnterRule("TYPEOF", 100);
		TraceIn("TYPEOF", 100);
		try
		{
			int _type = TYPEOF;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:187:8: ( 'typeof' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:187:10: 'typeof'
			{
			DebugLocation(187, 10);
			Match("typeof"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("TYPEOF", 100);
			LeaveRule("TYPEOF", 100);
			Leave_TYPEOF();
		}
	}
	// $ANTLR end "TYPEOF"

	partial void Enter_VAR();
	partial void Leave_VAR();

	// $ANTLR start "VAR"
	[GrammarRule("VAR")]
	private void mVAR()
	{
		Enter_VAR();
		EnterRule("VAR", 101);
		TraceIn("VAR", 101);
		try
		{
			int _type = VAR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:188:5: ( 'var' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:188:7: 'var'
			{
			DebugLocation(188, 7);
			Match("var"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VAR", 101);
			LeaveRule("VAR", 101);
			Leave_VAR();
		}
	}
	// $ANTLR end "VAR"

	partial void Enter_VOID();
	partial void Leave_VOID();

	// $ANTLR start "VOID"
	[GrammarRule("VOID")]
	private void mVOID()
	{
		Enter_VOID();
		EnterRule("VOID", 102);
		TraceIn("VOID", 102);
		try
		{
			int _type = VOID;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:189:6: ( 'void' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:189:8: 'void'
			{
			DebugLocation(189, 8);
			Match("void"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VOID", 102);
			LeaveRule("VOID", 102);
			Leave_VOID();
		}
	}
	// $ANTLR end "VOID"

	partial void Enter_VOLATILE();
	partial void Leave_VOLATILE();

	// $ANTLR start "VOLATILE"
	[GrammarRule("VOLATILE")]
	private void mVOLATILE()
	{
		Enter_VOLATILE();
		EnterRule("VOLATILE", 103);
		TraceIn("VOLATILE", 103);
		try
		{
			int _type = VOLATILE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:190:10: ( 'volatile' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:190:12: 'volatile'
			{
			DebugLocation(190, 12);
			Match("volatile"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("VOLATILE", 103);
			LeaveRule("VOLATILE", 103);
			Leave_VOLATILE();
		}
	}
	// $ANTLR end "VOLATILE"

	partial void Enter_WHILE();
	partial void Leave_WHILE();

	// $ANTLR start "WHILE"
	[GrammarRule("WHILE")]
	private void mWHILE()
	{
		Enter_WHILE();
		EnterRule("WHILE", 104);
		TraceIn("WHILE", 104);
		try
		{
			int _type = WHILE;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:191:7: ( 'while' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:191:9: 'while'
			{
			DebugLocation(191, 9);
			Match("while"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WHILE", 104);
			LeaveRule("WHILE", 104);
			Leave_WHILE();
		}
	}
	// $ANTLR end "WHILE"

	partial void Enter_WITH();
	partial void Leave_WITH();

	// $ANTLR start "WITH"
	[GrammarRule("WITH")]
	private void mWITH()
	{
		Enter_WITH();
		EnterRule("WITH", 105);
		TraceIn("WITH", 105);
		try
		{
			int _type = WITH;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:192:6: ( 'with' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:192:8: 'with'
			{
			DebugLocation(192, 8);
			Match("with"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WITH", 105);
			LeaveRule("WITH", 105);
			Leave_WITH();
		}
	}
	// $ANTLR end "WITH"

	partial void Enter_XOR();
	partial void Leave_XOR();

	// $ANTLR start "XOR"
	[GrammarRule("XOR")]
	private void mXOR()
	{
		Enter_XOR();
		EnterRule("XOR", 106);
		TraceIn("XOR", 106);
		try
		{
			int _type = XOR;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:193:5: ( '^' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:193:7: '^'
			{
			DebugLocation(193, 7);
			Match('^'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("XOR", 106);
			LeaveRule("XOR", 106);
			Leave_XOR();
		}
	}
	// $ANTLR end "XOR"

	partial void Enter_XORASS();
	partial void Leave_XORASS();

	// $ANTLR start "XORASS"
	[GrammarRule("XORASS")]
	private void mXORASS()
	{
		Enter_XORASS();
		EnterRule("XORASS", 107);
		TraceIn("XORASS", 107);
		try
		{
			int _type = XORASS;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:194:8: ( '^=' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:194:10: '^='
			{
			DebugLocation(194, 10);
			Match("^="); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("XORASS", 107);
			LeaveRule("XORASS", 107);
			Leave_XORASS();
		}
	}
	// $ANTLR end "XORASS"

	partial void Enter_BSLASH();
	partial void Leave_BSLASH();

	// $ANTLR start "BSLASH"
	[GrammarRule("BSLASH")]
	private void mBSLASH()
	{
		Enter_BSLASH();
		EnterRule("BSLASH", 108);
		TraceIn("BSLASH", 108);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:559:2: ( '\\\\' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:559:4: '\\\\'
			{
			DebugLocation(559, 4);
			Match('\\'); 

			}

		}
		finally
		{
			TraceOut("BSLASH", 108);
			LeaveRule("BSLASH", 108);
			Leave_BSLASH();
		}
	}
	// $ANTLR end "BSLASH"

	partial void Enter_DQUOTE();
	partial void Leave_DQUOTE();

	// $ANTLR start "DQUOTE"
	[GrammarRule("DQUOTE")]
	private void mDQUOTE()
	{
		Enter_DQUOTE();
		EnterRule("DQUOTE", 109);
		TraceIn("DQUOTE", 109);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:563:2: ( '\"' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:563:4: '\"'
			{
			DebugLocation(563, 4);
			Match('\"'); 

			}

		}
		finally
		{
			TraceOut("DQUOTE", 109);
			LeaveRule("DQUOTE", 109);
			Leave_DQUOTE();
		}
	}
	// $ANTLR end "DQUOTE"

	partial void Enter_SQUOTE();
	partial void Leave_SQUOTE();

	// $ANTLR start "SQUOTE"
	[GrammarRule("SQUOTE")]
	private void mSQUOTE()
	{
		Enter_SQUOTE();
		EnterRule("SQUOTE", 110);
		TraceIn("SQUOTE", 110);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:567:2: ( '\\'' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:567:4: '\\''
			{
			DebugLocation(567, 4);
			Match('\''); 

			}

		}
		finally
		{
			TraceOut("SQUOTE", 110);
			LeaveRule("SQUOTE", 110);
			Leave_SQUOTE();
		}
	}
	// $ANTLR end "SQUOTE"

	partial void Enter_TAB();
	partial void Leave_TAB();

	// $ANTLR start "TAB"
	[GrammarRule("TAB")]
	private void mTAB()
	{
		Enter_TAB();
		EnterRule("TAB", 111);
		TraceIn("TAB", 111);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:573:2: ( '\\u0009' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:573:4: '\\u0009'
			{
			DebugLocation(573, 4);
			Match('\t'); 

			}

		}
		finally
		{
			TraceOut("TAB", 111);
			LeaveRule("TAB", 111);
			Leave_TAB();
		}
	}
	// $ANTLR end "TAB"

	partial void Enter_VT();
	partial void Leave_VT();

	// $ANTLR start "VT"
	[GrammarRule("VT")]
	private void mVT()
	{
		Enter_VT();
		EnterRule("VT", 112);
		TraceIn("VT", 112);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:577:2: ( '\\u000b' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:577:4: '\\u000b'
			{
			DebugLocation(577, 4);
			Match('\u000B'); 

			}

		}
		finally
		{
			TraceOut("VT", 112);
			LeaveRule("VT", 112);
			Leave_VT();
		}
	}
	// $ANTLR end "VT"

	partial void Enter_FF();
	partial void Leave_FF();

	// $ANTLR start "FF"
	[GrammarRule("FF")]
	private void mFF()
	{
		Enter_FF();
		EnterRule("FF", 113);
		TraceIn("FF", 113);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:581:2: ( '\\u000c' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:581:4: '\\u000c'
			{
			DebugLocation(581, 4);
			Match('\f'); 

			}

		}
		finally
		{
			TraceOut("FF", 113);
			LeaveRule("FF", 113);
			Leave_FF();
		}
	}
	// $ANTLR end "FF"

	partial void Enter_SP();
	partial void Leave_SP();

	// $ANTLR start "SP"
	[GrammarRule("SP")]
	private void mSP()
	{
		Enter_SP();
		EnterRule("SP", 114);
		TraceIn("SP", 114);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:585:2: ( '\\u0020' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:585:4: '\\u0020'
			{
			DebugLocation(585, 4);
			Match(' '); 

			}

		}
		finally
		{
			TraceOut("SP", 114);
			LeaveRule("SP", 114);
			Leave_SP();
		}
	}
	// $ANTLR end "SP"

	partial void Enter_NBSP();
	partial void Leave_NBSP();

	// $ANTLR start "NBSP"
	[GrammarRule("NBSP")]
	private void mNBSP()
	{
		Enter_NBSP();
		EnterRule("NBSP", 115);
		TraceIn("NBSP", 115);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:589:2: ( '\\u00a0' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:589:4: '\\u00a0'
			{
			DebugLocation(589, 4);
			Match('\u00A0'); 

			}

		}
		finally
		{
			TraceOut("NBSP", 115);
			LeaveRule("NBSP", 115);
			Leave_NBSP();
		}
	}
	// $ANTLR end "NBSP"

	partial void Enter_USP();
	partial void Leave_USP();

	// $ANTLR start "USP"
	[GrammarRule("USP")]
	private void mUSP()
	{
		Enter_USP();
		EnterRule("USP", 116);
		TraceIn("USP", 116);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:593:2: ( '\\u1680' | '\\u180E' | '\\u2000' | '\\u2001' | '\\u2002' | '\\u2003' | '\\u2004' | '\\u2005' | '\\u2006' | '\\u2007' | '\\u2008' | '\\u2009' | '\\u200A' | '\\u202F' | '\\u205F' | '\\u3000' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(593, 2);
			if (input.LA(1)=='\u1680'||input.LA(1)=='\u180E'||(input.LA(1)>='\u2000' && input.LA(1)<='\u200A')||input.LA(1)=='\u202F'||input.LA(1)=='\u205F'||input.LA(1)=='\u3000')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("USP", 116);
			LeaveRule("USP", 116);
			Leave_USP();
		}
	}
	// $ANTLR end "USP"

	partial void Enter_WhiteSpace();
	partial void Leave_WhiteSpace();

	// $ANTLR start "WhiteSpace"
	[GrammarRule("WhiteSpace")]
	private void mWhiteSpace()
	{
		Enter_WhiteSpace();
		EnterRule("WhiteSpace", 117);
		TraceIn("WhiteSpace", 117);
		try
		{
			int _type = WhiteSpace;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:612:2: ( ( TAB | VT | FF | SP | NBSP | USP )+ )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:612:4: ( TAB | VT | FF | SP | NBSP | USP )+
			{
			DebugLocation(612, 4);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:612:4: ( TAB | VT | FF | SP | NBSP | USP )+
			int cnt1=0;
			try { DebugEnterSubRule(1);
			while (true)
			{
				int alt1=2;
				try { DebugEnterDecision(1, decisionCanBacktrack[1]);
				int LA1_0 = input.LA(1);

				if ((LA1_0=='\t'||(LA1_0>='\u000B' && LA1_0<='\f')||LA1_0==' '||LA1_0=='\u00A0'||LA1_0=='\u1680'||LA1_0=='\u180E'||(LA1_0>='\u2000' && LA1_0<='\u200A')||LA1_0=='\u202F'||LA1_0=='\u205F'||LA1_0=='\u3000'))
				{
					alt1=1;
				}


				} finally { DebugExitDecision(1); }
				switch (alt1)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
					{
					DebugLocation(612, 4);
					input.Consume();


					}
					break;

				default:
					if (cnt1 >= 1)
						goto loop1;

					EarlyExitException eee1 = new EarlyExitException( 1, input );
					DebugRecognitionException(eee1);
					throw eee1;
				}
				cnt1++;
			}
			loop1:
				;

			} finally { DebugExitSubRule(1); }

			DebugLocation(612, 41);
			 _channel = Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("WhiteSpace", 117);
			LeaveRule("WhiteSpace", 117);
			Leave_WhiteSpace();
		}
	}
	// $ANTLR end "WhiteSpace"

	partial void Enter_LF();
	partial void Leave_LF();

	// $ANTLR start "LF"
	[GrammarRule("LF")]
	private void mLF()
	{
		Enter_LF();
		EnterRule("LF", 118);
		TraceIn("LF", 118);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:620:2: ( '\\n' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:620:4: '\\n'
			{
			DebugLocation(620, 4);
			Match('\n'); 

			}

		}
		finally
		{
			TraceOut("LF", 118);
			LeaveRule("LF", 118);
			Leave_LF();
		}
	}
	// $ANTLR end "LF"

	partial void Enter_CR();
	partial void Leave_CR();

	// $ANTLR start "CR"
	[GrammarRule("CR")]
	private void mCR()
	{
		Enter_CR();
		EnterRule("CR", 119);
		TraceIn("CR", 119);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:624:2: ( '\\r' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:624:4: '\\r'
			{
			DebugLocation(624, 4);
			Match('\r'); 

			}

		}
		finally
		{
			TraceOut("CR", 119);
			LeaveRule("CR", 119);
			Leave_CR();
		}
	}
	// $ANTLR end "CR"

	partial void Enter_LS();
	partial void Leave_LS();

	// $ANTLR start "LS"
	[GrammarRule("LS")]
	private void mLS()
	{
		Enter_LS();
		EnterRule("LS", 120);
		TraceIn("LS", 120);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:628:2: ( '\\u2028' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:628:4: '\\u2028'
			{
			DebugLocation(628, 4);
			Match('\u2028'); 

			}

		}
		finally
		{
			TraceOut("LS", 120);
			LeaveRule("LS", 120);
			Leave_LS();
		}
	}
	// $ANTLR end "LS"

	partial void Enter_PS();
	partial void Leave_PS();

	// $ANTLR start "PS"
	[GrammarRule("PS")]
	private void mPS()
	{
		Enter_PS();
		EnterRule("PS", 121);
		TraceIn("PS", 121);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:632:2: ( '\\u2029' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:632:4: '\\u2029'
			{
			DebugLocation(632, 4);
			Match('\u2029'); 

			}

		}
		finally
		{
			TraceOut("PS", 121);
			LeaveRule("PS", 121);
			Leave_PS();
		}
	}
	// $ANTLR end "PS"

	partial void Enter_LineTerminator();
	partial void Leave_LineTerminator();

	// $ANTLR start "LineTerminator"
	[GrammarRule("LineTerminator")]
	private void mLineTerminator()
	{
		Enter_LineTerminator();
		EnterRule("LineTerminator", 122);
		TraceIn("LineTerminator", 122);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:636:2: ( CR | LF | LS | PS )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(636, 2);
			if (input.LA(1)=='\n'||input.LA(1)=='\r'||(input.LA(1)>='\u2028' && input.LA(1)<='\u2029'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("LineTerminator", 122);
			LeaveRule("LineTerminator", 122);
			Leave_LineTerminator();
		}
	}
	// $ANTLR end "LineTerminator"

	partial void Enter_EOL();
	partial void Leave_EOL();

	// $ANTLR start "EOL"
	[GrammarRule("EOL")]
	private void mEOL()
	{
		Enter_EOL();
		EnterRule("EOL", 123);
		TraceIn("EOL", 123);
		try
		{
			int _type = EOL;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:2: ( ( ( CR LF ) | LF | LS | PS ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:4: ( ( CR LF ) | LF | LS | PS )
			{
			DebugLocation(640, 4);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:4: ( ( CR LF ) | LF | LS | PS )
			int alt2=4;
			try { DebugEnterSubRule(2);
			try { DebugEnterDecision(2, decisionCanBacktrack[2]);
			switch (input.LA(1))
			{
			case '\r':
				{
				alt2=1;
				}
				break;
			case '\n':
				{
				alt2=2;
				}
				break;
			case '\u2028':
				{
				alt2=3;
				}
				break;
			case '\u2029':
				{
				alt2=4;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 2, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(2); }
			switch (alt2)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:6: ( CR LF )
				{
				DebugLocation(640, 6);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:6: ( CR LF )
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:8: CR LF
				{
				DebugLocation(640, 8);
				mCR(); 
				DebugLocation(640, 11);
				mLF(); 

				}


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:18: LF
				{
				DebugLocation(640, 18);
				mLF(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:23: LS
				{
				DebugLocation(640, 23);
				mLS(); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:640:28: PS
				{
				DebugLocation(640, 28);
				mPS(); 

				}
				break;

			}
			} finally { DebugExitSubRule(2); }

			DebugLocation(640, 33);
			 _channel = Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("EOL", 123);
			LeaveRule("EOL", 123);
			Leave_EOL();
		}
	}
	// $ANTLR end "EOL"

	partial void Enter_MultiLineComment();
	partial void Leave_MultiLineComment();

	// $ANTLR start "MultiLineComment"
	[GrammarRule("MultiLineComment")]
	private void mMultiLineComment()
	{
		Enter_MultiLineComment();
		EnterRule("MultiLineComment", 124);
		TraceIn("MultiLineComment", 124);
		try
		{
			int _type = MultiLineComment;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:647:2: ( '/*' ( options {greedy=false; } : . )* '*/' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:647:4: '/*' ( options {greedy=false; } : . )* '*/'
			{
			DebugLocation(647, 4);
			Match("/*"); 

			DebugLocation(647, 9);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:647:9: ( options {greedy=false; } : . )*
			try { DebugEnterSubRule(3);
			while (true)
			{
				int alt3=2;
				try { DebugEnterDecision(3, decisionCanBacktrack[3]);
				int LA3_0 = input.LA(1);

				if ((LA3_0=='*'))
				{
					int LA3_1 = input.LA(2);

					if ((LA3_1=='/'))
					{
						alt3=2;
					}
					else if (((LA3_1>='\u0000' && LA3_1<='.')||(LA3_1>='0' && LA3_1<='\uFFFF')))
					{
						alt3=1;
					}


				}
				else if (((LA3_0>='\u0000' && LA3_0<=')')||(LA3_0>='+' && LA3_0<='\uFFFF')))
				{
					alt3=1;
				}


				} finally { DebugExitDecision(3); }
				switch ( alt3 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:647:41: .
					{
					DebugLocation(647, 41);
					MatchAny(); 

					}
					break;

				default:
					goto loop3;
				}
			}

			loop3:
				;

			} finally { DebugExitSubRule(3); }

			DebugLocation(647, 46);
			Match("*/"); 

			DebugLocation(647, 51);
			 _channel = Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("MultiLineComment", 124);
			LeaveRule("MultiLineComment", 124);
			Leave_MultiLineComment();
		}
	}
	// $ANTLR end "MultiLineComment"

	partial void Enter_SingleLineComment();
	partial void Leave_SingleLineComment();

	// $ANTLR start "SingleLineComment"
	[GrammarRule("SingleLineComment")]
	private void mSingleLineComment()
	{
		Enter_SingleLineComment();
		EnterRule("SingleLineComment", 125);
		TraceIn("SingleLineComment", 125);
		try
		{
			int _type = SingleLineComment;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:651:2: ( '//' (~ ( LineTerminator ) )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:651:4: '//' (~ ( LineTerminator ) )*
			{
			DebugLocation(651, 4);
			Match("//"); 

			DebugLocation(651, 9);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:651:9: (~ ( LineTerminator ) )*
			try { DebugEnterSubRule(4);
			while (true)
			{
				int alt4=2;
				try { DebugEnterDecision(4, decisionCanBacktrack[4]);
				int LA4_0 = input.LA(1);

				if (((LA4_0>='\u0000' && LA4_0<='\t')||(LA4_0>='\u000B' && LA4_0<='\f')||(LA4_0>='\u000E' && LA4_0<='\u2027')||(LA4_0>='\u202A' && LA4_0<='\uFFFF')))
				{
					alt4=1;
				}


				} finally { DebugExitDecision(4); }
				switch ( alt4 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
					{
					DebugLocation(651, 9);
					input.Consume();


					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;

			} finally { DebugExitSubRule(4); }

			DebugLocation(651, 34);
			 _channel = Hidden; 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("SingleLineComment", 125);
			LeaveRule("SingleLineComment", 125);
			Leave_SingleLineComment();
		}
	}
	// $ANTLR end "SingleLineComment"

	partial void Enter_IdentifierStartASCII();
	partial void Leave_IdentifierStartASCII();

	// $ANTLR start "IdentifierStartASCII"
	[GrammarRule("IdentifierStartASCII")]
	private void mIdentifierStartASCII()
	{
		Enter_IdentifierStartASCII();
		EnterRule("IdentifierStartASCII", 126);
		TraceIn("IdentifierStartASCII", 126);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:752:2: ( 'a' .. 'z' | 'A' .. 'Z' | '$' | '_' | BSLASH 'u' HexDigit HexDigit HexDigit HexDigit )
			int alt5=5;
			try { DebugEnterDecision(5, decisionCanBacktrack[5]);
			switch (input.LA(1))
			{
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				{
				alt5=1;
				}
				break;
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
				{
				alt5=2;
				}
				break;
			case '$':
				{
				alt5=3;
				}
				break;
			case '_':
				{
				alt5=4;
				}
				break;
			case '\\':
				{
				alt5=5;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 5, 0, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}

			} finally { DebugExitDecision(5); }
			switch (alt5)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:752:4: 'a' .. 'z'
				{
				DebugLocation(752, 4);
				MatchRange('a','z'); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:752:15: 'A' .. 'Z'
				{
				DebugLocation(752, 15);
				MatchRange('A','Z'); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:753:4: '$'
				{
				DebugLocation(753, 4);
				Match('$'); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:754:4: '_'
				{
				DebugLocation(754, 4);
				Match('_'); 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:755:4: BSLASH 'u' HexDigit HexDigit HexDigit HexDigit
				{
				DebugLocation(755, 4);
				mBSLASH(); 
				DebugLocation(755, 11);
				Match('u'); 
				DebugLocation(755, 15);
				mHexDigit(); 
				DebugLocation(755, 24);
				mHexDigit(); 
				DebugLocation(755, 33);
				mHexDigit(); 
				DebugLocation(755, 42);
				mHexDigit(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("IdentifierStartASCII", 126);
			LeaveRule("IdentifierStartASCII", 126);
			Leave_IdentifierStartASCII();
		}
	}
	// $ANTLR end "IdentifierStartASCII"

	partial void Enter_IdentifierPart();
	partial void Leave_IdentifierPart();

	// $ANTLR start "IdentifierPart"
	[GrammarRule("IdentifierPart")]
	private void mIdentifierPart()
	{
		Enter_IdentifierPart();
		EnterRule("IdentifierPart", 127);
		TraceIn("IdentifierPart", 127);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:763:2: ( DecimalDigit | IdentifierStartASCII |{...}?)
			int alt6=3;
			try { DebugEnterDecision(6, decisionCanBacktrack[6]);
			switch (input.LA(1))
			{
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
				{
				alt6=1;
				}
				break;
			case '$':
			case 'A':
			case 'B':
			case 'C':
			case 'D':
			case 'E':
			case 'F':
			case 'G':
			case 'H':
			case 'I':
			case 'J':
			case 'K':
			case 'L':
			case 'M':
			case 'N':
			case 'O':
			case 'P':
			case 'Q':
			case 'R':
			case 'S':
			case 'T':
			case 'U':
			case 'V':
			case 'W':
			case 'X':
			case 'Y':
			case 'Z':
			case '\\':
			case '_':
			case 'a':
			case 'b':
			case 'c':
			case 'd':
			case 'e':
			case 'f':
			case 'g':
			case 'h':
			case 'i':
			case 'j':
			case 'k':
			case 'l':
			case 'm':
			case 'n':
			case 'o':
			case 'p':
			case 'q':
			case 'r':
			case 's':
			case 't':
			case 'u':
			case 'v':
			case 'w':
			case 'x':
			case 'y':
			case 'z':
				{
				alt6=2;
				}
				break;
			default:
				alt6=3;
				break;
			}

			} finally { DebugExitDecision(6); }
			switch (alt6)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:763:4: DecimalDigit
				{
				DebugLocation(763, 4);
				mDecimalDigit(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:764:4: IdentifierStartASCII
				{
				DebugLocation(764, 4);
				mIdentifierStartASCII(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:765:4: {...}?
				{
				DebugLocation(765, 4);
				if (!(( IsIdentifierPartUnicode(input.LA(1)) )))
				{
					throw new FailedPredicateException(input, "IdentifierPart", " IsIdentifierPartUnicode(input.LA(1)) ");
				}
				DebugLocation(765, 46);
				 MatchAny(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("IdentifierPart", 127);
			LeaveRule("IdentifierPart", 127);
			Leave_IdentifierPart();
		}
	}
	// $ANTLR end "IdentifierPart"

	partial void Enter_IdentifierNameASCIIStart();
	partial void Leave_IdentifierNameASCIIStart();

	// $ANTLR start "IdentifierNameASCIIStart"
	[GrammarRule("IdentifierNameASCIIStart")]
	private void mIdentifierNameASCIIStart()
	{
		Enter_IdentifierNameASCIIStart();
		EnterRule("IdentifierNameASCIIStart", 128);
		TraceIn("IdentifierNameASCIIStart", 128);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:769:2: ( IdentifierStartASCII ( IdentifierPart )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:769:4: IdentifierStartASCII ( IdentifierPart )*
			{
			DebugLocation(769, 4);
			mIdentifierStartASCII(); 
			DebugLocation(769, 25);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:769:25: ( IdentifierPart )*
			try { DebugEnterSubRule(7);
			while (true)
			{
				int alt7=2;
				try { DebugEnterDecision(7, decisionCanBacktrack[7]);
				int LA7_0 = input.LA(1);

				if ((LA7_0=='$'||(LA7_0>='0' && LA7_0<='9')||(LA7_0>='A' && LA7_0<='Z')||LA7_0=='\\'||LA7_0=='_'||(LA7_0>='a' && LA7_0<='z')))
				{
					alt7=1;
				}
				else if ((( IsIdentifierPartUnicode(input.LA(1)) )))
				{
					alt7=1;
				}


				} finally { DebugExitDecision(7); }
				switch ( alt7 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:769:25: IdentifierPart
					{
					DebugLocation(769, 25);
					mIdentifierPart(); 

					}
					break;

				default:
					goto loop7;
				}
			}

			loop7:
				;

			} finally { DebugExitSubRule(7); }


			}

		}
		finally
		{
			TraceOut("IdentifierNameASCIIStart", 128);
			LeaveRule("IdentifierNameASCIIStart", 128);
			Leave_IdentifierNameASCIIStart();
		}
	}
	// $ANTLR end "IdentifierNameASCIIStart"

	partial void Enter_Identifier();
	partial void Leave_Identifier();

	// $ANTLR start "Identifier"
	[GrammarRule("Identifier")]
	private void mIdentifier()
	{
		Enter_Identifier();
		EnterRule("Identifier", 129);
		TraceIn("Identifier", 129);
		try
		{
			int _type = Identifier;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:781:2: ( IdentifierNameASCIIStart |)
			int alt8=2;
			try { DebugEnterDecision(8, decisionCanBacktrack[8]);
			int LA8_0 = input.LA(1);

			if ((LA8_0=='$'||(LA8_0>='A' && LA8_0<='Z')||LA8_0=='\\'||LA8_0=='_'||(LA8_0>='a' && LA8_0<='z')))
			{
				alt8=1;
			}
			else
			{
				alt8=2;}
			} finally { DebugExitDecision(8); }
			switch (alt8)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:781:4: IdentifierNameASCIIStart
				{
				DebugLocation(781, 4);
				mIdentifierNameASCIIStart(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:782:4: 
				{
				DebugLocation(782, 4);
				 ConsumeIdentifierUnicodeStart(); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("Identifier", 129);
			LeaveRule("Identifier", 129);
			Leave_Identifier();
		}
	}
	// $ANTLR end "Identifier"

	partial void Enter_DecimalDigit();
	partial void Leave_DecimalDigit();

	// $ANTLR start "DecimalDigit"
	[GrammarRule("DecimalDigit")]
	private void mDecimalDigit()
	{
		Enter_DecimalDigit();
		EnterRule("DecimalDigit", 130);
		TraceIn("DecimalDigit", 130);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:865:2: ( '0' .. '9' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(865, 2);
			if ((input.LA(1)>='0' && input.LA(1)<='9'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("DecimalDigit", 130);
			LeaveRule("DecimalDigit", 130);
			Leave_DecimalDigit();
		}
	}
	// $ANTLR end "DecimalDigit"

	partial void Enter_HexDigit();
	partial void Leave_HexDigit();

	// $ANTLR start "HexDigit"
	[GrammarRule("HexDigit")]
	private void mHexDigit()
	{
		Enter_HexDigit();
		EnterRule("HexDigit", 131);
		TraceIn("HexDigit", 131);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:869:2: ( DecimalDigit | 'a' .. 'f' | 'A' .. 'F' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(869, 2);
			if ((input.LA(1)>='0' && input.LA(1)<='9')||(input.LA(1)>='A' && input.LA(1)<='F')||(input.LA(1)>='a' && input.LA(1)<='f'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("HexDigit", 131);
			LeaveRule("HexDigit", 131);
			Leave_HexDigit();
		}
	}
	// $ANTLR end "HexDigit"

	partial void Enter_OctalDigit();
	partial void Leave_OctalDigit();

	// $ANTLR start "OctalDigit"
	[GrammarRule("OctalDigit")]
	private void mOctalDigit()
	{
		Enter_OctalDigit();
		EnterRule("OctalDigit", 132);
		TraceIn("OctalDigit", 132);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:873:2: ( '0' .. '7' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(873, 2);
			if ((input.LA(1)>='0' && input.LA(1)<='7'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("OctalDigit", 132);
			LeaveRule("OctalDigit", 132);
			Leave_OctalDigit();
		}
	}
	// $ANTLR end "OctalDigit"

	partial void Enter_ExponentPart();
	partial void Leave_ExponentPart();

	// $ANTLR start "ExponentPart"
	[GrammarRule("ExponentPart")]
	private void mExponentPart()
	{
		Enter_ExponentPart();
		EnterRule("ExponentPart", 133);
		TraceIn("ExponentPart", 133);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:877:2: ( ( 'e' | 'E' ) ( '+' | '-' )? ( DecimalDigit )+ )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:877:4: ( 'e' | 'E' ) ( '+' | '-' )? ( DecimalDigit )+
			{
			DebugLocation(877, 4);
			if (input.LA(1)=='E'||input.LA(1)=='e')
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}

			DebugLocation(877, 18);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:877:18: ( '+' | '-' )?
			int alt9=2;
			try { DebugEnterSubRule(9);
			try { DebugEnterDecision(9, decisionCanBacktrack[9]);
			int LA9_0 = input.LA(1);

			if ((LA9_0=='+'||LA9_0=='-'))
			{
				alt9=1;
			}
			} finally { DebugExitDecision(9); }
			switch (alt9)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
				{
				DebugLocation(877, 18);
				input.Consume();


				}
				break;

			}
			} finally { DebugExitSubRule(9); }

			DebugLocation(877, 33);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:877:33: ( DecimalDigit )+
			int cnt10=0;
			try { DebugEnterSubRule(10);
			while (true)
			{
				int alt10=2;
				try { DebugEnterDecision(10, decisionCanBacktrack[10]);
				int LA10_0 = input.LA(1);

				if (((LA10_0>='0' && LA10_0<='9')))
				{
					alt10=1;
				}


				} finally { DebugExitDecision(10); }
				switch (alt10)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
					{
					DebugLocation(877, 33);
					input.Consume();


					}
					break;

				default:
					if (cnt10 >= 1)
						goto loop10;

					EarlyExitException eee10 = new EarlyExitException( 10, input );
					DebugRecognitionException(eee10);
					throw eee10;
				}
				cnt10++;
			}
			loop10:
				;

			} finally { DebugExitSubRule(10); }


			}

		}
		finally
		{
			TraceOut("ExponentPart", 133);
			LeaveRule("ExponentPart", 133);
			Leave_ExponentPart();
		}
	}
	// $ANTLR end "ExponentPart"

	partial void Enter_DecimalIntegerLiteral();
	partial void Leave_DecimalIntegerLiteral();

	// $ANTLR start "DecimalIntegerLiteral"
	[GrammarRule("DecimalIntegerLiteral")]
	private void mDecimalIntegerLiteral()
	{
		Enter_DecimalIntegerLiteral();
		EnterRule("DecimalIntegerLiteral", 134);
		TraceIn("DecimalIntegerLiteral", 134);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:881:2: ( '0' | '1' .. '9' ( DecimalDigit )* )
			int alt12=2;
			try { DebugEnterDecision(12, decisionCanBacktrack[12]);
			int LA12_0 = input.LA(1);

			if ((LA12_0=='0'))
			{
				alt12=1;
			}
			else if (((LA12_0>='1' && LA12_0<='9')))
			{
				alt12=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 12, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(12); }
			switch (alt12)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:881:4: '0'
				{
				DebugLocation(881, 4);
				Match('0'); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:882:4: '1' .. '9' ( DecimalDigit )*
				{
				DebugLocation(882, 4);
				MatchRange('1','9'); 
				DebugLocation(882, 13);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:882:13: ( DecimalDigit )*
				try { DebugEnterSubRule(11);
				while (true)
				{
					int alt11=2;
					try { DebugEnterDecision(11, decisionCanBacktrack[11]);
					int LA11_0 = input.LA(1);

					if (((LA11_0>='0' && LA11_0<='9')))
					{
						alt11=1;
					}


					} finally { DebugExitDecision(11); }
					switch ( alt11 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
						{
						DebugLocation(882, 13);
						input.Consume();


						}
						break;

					default:
						goto loop11;
					}
				}

				loop11:
					;

				} finally { DebugExitSubRule(11); }


				}
				break;

			}
		}
		finally
		{
			TraceOut("DecimalIntegerLiteral", 134);
			LeaveRule("DecimalIntegerLiteral", 134);
			Leave_DecimalIntegerLiteral();
		}
	}
	// $ANTLR end "DecimalIntegerLiteral"

	partial void Enter_DecimalLiteral();
	partial void Leave_DecimalLiteral();

	// $ANTLR start "DecimalLiteral"
	[GrammarRule("DecimalLiteral")]
	private void mDecimalLiteral()
	{
		Enter_DecimalLiteral();
		EnterRule("DecimalLiteral", 135);
		TraceIn("DecimalLiteral", 135);
		try
		{
			int _type = DecimalLiteral;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:886:2: ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | DecimalIntegerLiteral ( ExponentPart )? )
			int alt18=3;
			try { DebugEnterDecision(18, decisionCanBacktrack[18]);
			try
			{
				alt18 = dfa18.Predict(input);
			}
			catch (NoViableAltException nvae)
			{
				DebugRecognitionException(nvae);
				throw;
			}
			} finally { DebugExitDecision(18); }
			switch (alt18)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:886:4: DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )?
				{
				DebugLocation(886, 4);
				mDecimalIntegerLiteral(); 
				DebugLocation(886, 26);
				Match('.'); 
				DebugLocation(886, 30);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:886:30: ( DecimalDigit )*
				try { DebugEnterSubRule(13);
				while (true)
				{
					int alt13=2;
					try { DebugEnterDecision(13, decisionCanBacktrack[13]);
					int LA13_0 = input.LA(1);

					if (((LA13_0>='0' && LA13_0<='9')))
					{
						alt13=1;
					}


					} finally { DebugExitDecision(13); }
					switch ( alt13 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
						{
						DebugLocation(886, 30);
						input.Consume();


						}
						break;

					default:
						goto loop13;
					}
				}

				loop13:
					;

				} finally { DebugExitSubRule(13); }

				DebugLocation(886, 44);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:886:44: ( ExponentPart )?
				int alt14=2;
				try { DebugEnterSubRule(14);
				try { DebugEnterDecision(14, decisionCanBacktrack[14]);
				int LA14_0 = input.LA(1);

				if ((LA14_0=='E'||LA14_0=='e'))
				{
					alt14=1;
				}
				} finally { DebugExitDecision(14); }
				switch (alt14)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:886:44: ExponentPart
					{
					DebugLocation(886, 44);
					mExponentPart(); 

					}
					break;

				}
				} finally { DebugExitSubRule(14); }


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:887:4: '.' ( DecimalDigit )+ ( ExponentPart )?
				{
				DebugLocation(887, 4);
				Match('.'); 
				DebugLocation(887, 8);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:887:8: ( DecimalDigit )+
				int cnt15=0;
				try { DebugEnterSubRule(15);
				while (true)
				{
					int alt15=2;
					try { DebugEnterDecision(15, decisionCanBacktrack[15]);
					int LA15_0 = input.LA(1);

					if (((LA15_0>='0' && LA15_0<='9')))
					{
						alt15=1;
					}


					} finally { DebugExitDecision(15); }
					switch (alt15)
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
						{
						DebugLocation(887, 8);
						input.Consume();


						}
						break;

					default:
						if (cnt15 >= 1)
							goto loop15;

						EarlyExitException eee15 = new EarlyExitException( 15, input );
						DebugRecognitionException(eee15);
						throw eee15;
					}
					cnt15++;
				}
				loop15:
					;

				} finally { DebugExitSubRule(15); }

				DebugLocation(887, 22);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:887:22: ( ExponentPart )?
				int alt16=2;
				try { DebugEnterSubRule(16);
				try { DebugEnterDecision(16, decisionCanBacktrack[16]);
				int LA16_0 = input.LA(1);

				if ((LA16_0=='E'||LA16_0=='e'))
				{
					alt16=1;
				}
				} finally { DebugExitDecision(16); }
				switch (alt16)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:887:22: ExponentPart
					{
					DebugLocation(887, 22);
					mExponentPart(); 

					}
					break;

				}
				} finally { DebugExitSubRule(16); }


				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:888:4: DecimalIntegerLiteral ( ExponentPart )?
				{
				DebugLocation(888, 4);
				mDecimalIntegerLiteral(); 
				DebugLocation(888, 26);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:888:26: ( ExponentPart )?
				int alt17=2;
				try { DebugEnterSubRule(17);
				try { DebugEnterDecision(17, decisionCanBacktrack[17]);
				int LA17_0 = input.LA(1);

				if ((LA17_0=='E'||LA17_0=='e'))
				{
					alt17=1;
				}
				} finally { DebugExitDecision(17); }
				switch (alt17)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:888:26: ExponentPart
					{
					DebugLocation(888, 26);
					mExponentPart(); 

					}
					break;

				}
				} finally { DebugExitSubRule(17); }


				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("DecimalLiteral", 135);
			LeaveRule("DecimalLiteral", 135);
			Leave_DecimalLiteral();
		}
	}
	// $ANTLR end "DecimalLiteral"

	partial void Enter_OctalIntegerLiteral();
	partial void Leave_OctalIntegerLiteral();

	// $ANTLR start "OctalIntegerLiteral"
	[GrammarRule("OctalIntegerLiteral")]
	private void mOctalIntegerLiteral()
	{
		Enter_OctalIntegerLiteral();
		EnterRule("OctalIntegerLiteral", 136);
		TraceIn("OctalIntegerLiteral", 136);
		try
		{
			int _type = OctalIntegerLiteral;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:892:2: ( '0' ( OctalDigit )+ )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:892:4: '0' ( OctalDigit )+
			{
			DebugLocation(892, 4);
			Match('0'); 
			DebugLocation(892, 8);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:892:8: ( OctalDigit )+
			int cnt19=0;
			try { DebugEnterSubRule(19);
			while (true)
			{
				int alt19=2;
				try { DebugEnterDecision(19, decisionCanBacktrack[19]);
				int LA19_0 = input.LA(1);

				if (((LA19_0>='0' && LA19_0<='7')))
				{
					alt19=1;
				}


				} finally { DebugExitDecision(19); }
				switch (alt19)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
					{
					DebugLocation(892, 8);
					input.Consume();


					}
					break;

				default:
					if (cnt19 >= 1)
						goto loop19;

					EarlyExitException eee19 = new EarlyExitException( 19, input );
					DebugRecognitionException(eee19);
					throw eee19;
				}
				cnt19++;
			}
			loop19:
				;

			} finally { DebugExitSubRule(19); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("OctalIntegerLiteral", 136);
			LeaveRule("OctalIntegerLiteral", 136);
			Leave_OctalIntegerLiteral();
		}
	}
	// $ANTLR end "OctalIntegerLiteral"

	partial void Enter_HexIntegerLiteral();
	partial void Leave_HexIntegerLiteral();

	// $ANTLR start "HexIntegerLiteral"
	[GrammarRule("HexIntegerLiteral")]
	private void mHexIntegerLiteral()
	{
		Enter_HexIntegerLiteral();
		EnterRule("HexIntegerLiteral", 137);
		TraceIn("HexIntegerLiteral", 137);
		try
		{
			int _type = HexIntegerLiteral;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:896:2: ( ( '0x' | '0X' ) ( HexDigit )+ )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:896:4: ( '0x' | '0X' ) ( HexDigit )+
			{
			DebugLocation(896, 4);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:896:4: ( '0x' | '0X' )
			int alt20=2;
			try { DebugEnterSubRule(20);
			try { DebugEnterDecision(20, decisionCanBacktrack[20]);
			int LA20_0 = input.LA(1);

			if ((LA20_0=='0'))
			{
				int LA20_1 = input.LA(2);

				if ((LA20_1=='x'))
				{
					alt20=1;
				}
				else if ((LA20_1=='X'))
				{
					alt20=2;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 20, 1, input);

					DebugRecognitionException(nvae);
					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 20, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(20); }
			switch (alt20)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:896:6: '0x'
				{
				DebugLocation(896, 6);
				Match("0x"); 


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:896:13: '0X'
				{
				DebugLocation(896, 13);
				Match("0X"); 


				}
				break;

			}
			} finally { DebugExitSubRule(20); }

			DebugLocation(896, 20);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:896:20: ( HexDigit )+
			int cnt21=0;
			try { DebugEnterSubRule(21);
			while (true)
			{
				int alt21=2;
				try { DebugEnterDecision(21, decisionCanBacktrack[21]);
				int LA21_0 = input.LA(1);

				if (((LA21_0>='0' && LA21_0<='9')||(LA21_0>='A' && LA21_0<='F')||(LA21_0>='a' && LA21_0<='f')))
				{
					alt21=1;
				}


				} finally { DebugExitDecision(21); }
				switch (alt21)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
					{
					DebugLocation(896, 20);
					input.Consume();


					}
					break;

				default:
					if (cnt21 >= 1)
						goto loop21;

					EarlyExitException eee21 = new EarlyExitException( 21, input );
					DebugRecognitionException(eee21);
					throw eee21;
				}
				cnt21++;
			}
			loop21:
				;

			} finally { DebugExitSubRule(21); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("HexIntegerLiteral", 137);
			LeaveRule("HexIntegerLiteral", 137);
			Leave_HexIntegerLiteral();
		}
	}
	// $ANTLR end "HexIntegerLiteral"

	partial void Enter_CharacterEscapeSequence();
	partial void Leave_CharacterEscapeSequence();

	// $ANTLR start "CharacterEscapeSequence"
	[GrammarRule("CharacterEscapeSequence")]
	private void mCharacterEscapeSequence()
	{
		Enter_CharacterEscapeSequence();
		EnterRule("CharacterEscapeSequence", 138);
		TraceIn("CharacterEscapeSequence", 138);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:915:2: (~ ( DecimalDigit | 'x' | 'u' | LineTerminator ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(915, 2);
			if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='/')||(input.LA(1)>=':' && input.LA(1)<='t')||(input.LA(1)>='v' && input.LA(1)<='w')||(input.LA(1)>='y' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("CharacterEscapeSequence", 138);
			LeaveRule("CharacterEscapeSequence", 138);
			Leave_CharacterEscapeSequence();
		}
	}
	// $ANTLR end "CharacterEscapeSequence"

	partial void Enter_ZeroToThree();
	partial void Leave_ZeroToThree();

	// $ANTLR start "ZeroToThree"
	[GrammarRule("ZeroToThree")]
	private void mZeroToThree()
	{
		Enter_ZeroToThree();
		EnterRule("ZeroToThree", 139);
		TraceIn("ZeroToThree", 139);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:919:2: ( '0' .. '3' )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
			{
			DebugLocation(919, 2);
			if ((input.LA(1)>='0' && input.LA(1)<='3'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("ZeroToThree", 139);
			LeaveRule("ZeroToThree", 139);
			Leave_ZeroToThree();
		}
	}
	// $ANTLR end "ZeroToThree"

	partial void Enter_OctalEscapeSequence();
	partial void Leave_OctalEscapeSequence();

	// $ANTLR start "OctalEscapeSequence"
	[GrammarRule("OctalEscapeSequence")]
	private void mOctalEscapeSequence()
	{
		Enter_OctalEscapeSequence();
		EnterRule("OctalEscapeSequence", 140);
		TraceIn("OctalEscapeSequence", 140);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:923:2: ( OctalDigit | ZeroToThree OctalDigit | '4' .. '7' OctalDigit | ZeroToThree OctalDigit OctalDigit )
			int alt22=4;
			try { DebugEnterDecision(22, decisionCanBacktrack[22]);
			int LA22_0 = input.LA(1);

			if (((LA22_0>='0' && LA22_0<='3')))
			{
				int LA22_1 = input.LA(2);

				if (((LA22_1>='0' && LA22_1<='7')))
				{
					int LA22_4 = input.LA(3);

					if (((LA22_4>='0' && LA22_4<='7')))
					{
						alt22=4;
					}
					else
					{
						alt22=2;}
				}
				else
				{
					alt22=1;}
			}
			else if (((LA22_0>='4' && LA22_0<='7')))
			{
				int LA22_2 = input.LA(2);

				if (((LA22_2>='0' && LA22_2<='7')))
				{
					alt22=3;
				}
				else
				{
					alt22=1;}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 22, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(22); }
			switch (alt22)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:923:4: OctalDigit
				{
				DebugLocation(923, 4);
				mOctalDigit(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:924:4: ZeroToThree OctalDigit
				{
				DebugLocation(924, 4);
				mZeroToThree(); 
				DebugLocation(924, 16);
				mOctalDigit(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:925:4: '4' .. '7' OctalDigit
				{
				DebugLocation(925, 4);
				MatchRange('4','7'); 
				DebugLocation(925, 13);
				mOctalDigit(); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:926:4: ZeroToThree OctalDigit OctalDigit
				{
				DebugLocation(926, 4);
				mZeroToThree(); 
				DebugLocation(926, 16);
				mOctalDigit(); 
				DebugLocation(926, 27);
				mOctalDigit(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("OctalEscapeSequence", 140);
			LeaveRule("OctalEscapeSequence", 140);
			Leave_OctalEscapeSequence();
		}
	}
	// $ANTLR end "OctalEscapeSequence"

	partial void Enter_HexEscapeSequence();
	partial void Leave_HexEscapeSequence();

	// $ANTLR start "HexEscapeSequence"
	[GrammarRule("HexEscapeSequence")]
	private void mHexEscapeSequence()
	{
		Enter_HexEscapeSequence();
		EnterRule("HexEscapeSequence", 141);
		TraceIn("HexEscapeSequence", 141);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:930:2: ( 'x' HexDigit HexDigit )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:930:4: 'x' HexDigit HexDigit
			{
			DebugLocation(930, 4);
			Match('x'); 
			DebugLocation(930, 8);
			mHexDigit(); 
			DebugLocation(930, 17);
			mHexDigit(); 

			}

		}
		finally
		{
			TraceOut("HexEscapeSequence", 141);
			LeaveRule("HexEscapeSequence", 141);
			Leave_HexEscapeSequence();
		}
	}
	// $ANTLR end "HexEscapeSequence"

	partial void Enter_UnicodeEscapeSequence();
	partial void Leave_UnicodeEscapeSequence();

	// $ANTLR start "UnicodeEscapeSequence"
	[GrammarRule("UnicodeEscapeSequence")]
	private void mUnicodeEscapeSequence()
	{
		Enter_UnicodeEscapeSequence();
		EnterRule("UnicodeEscapeSequence", 142);
		TraceIn("UnicodeEscapeSequence", 142);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:934:2: ( 'u' HexDigit HexDigit HexDigit HexDigit )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:934:4: 'u' HexDigit HexDigit HexDigit HexDigit
			{
			DebugLocation(934, 4);
			Match('u'); 
			DebugLocation(934, 8);
			mHexDigit(); 
			DebugLocation(934, 17);
			mHexDigit(); 
			DebugLocation(934, 26);
			mHexDigit(); 
			DebugLocation(934, 35);
			mHexDigit(); 

			}

		}
		finally
		{
			TraceOut("UnicodeEscapeSequence", 142);
			LeaveRule("UnicodeEscapeSequence", 142);
			Leave_UnicodeEscapeSequence();
		}
	}
	// $ANTLR end "UnicodeEscapeSequence"

	partial void Enter_EscapeSequence();
	partial void Leave_EscapeSequence();

	// $ANTLR start "EscapeSequence"
	[GrammarRule("EscapeSequence")]
	private void mEscapeSequence()
	{
		Enter_EscapeSequence();
		EnterRule("EscapeSequence", 143);
		TraceIn("EscapeSequence", 143);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:938:2: ( BSLASH ( CharacterEscapeSequence | OctalEscapeSequence | HexEscapeSequence | UnicodeEscapeSequence | ( CR )? LF ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:939:2: BSLASH ( CharacterEscapeSequence | OctalEscapeSequence | HexEscapeSequence | UnicodeEscapeSequence | ( CR )? LF )
			{
			DebugLocation(939, 2);
			mBSLASH(); 
			DebugLocation(940, 2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:940:2: ( CharacterEscapeSequence | OctalEscapeSequence | HexEscapeSequence | UnicodeEscapeSequence | ( CR )? LF )
			int alt24=5;
			try { DebugEnterSubRule(24);
			try { DebugEnterDecision(24, decisionCanBacktrack[24]);
			int LA24_0 = input.LA(1);

			if (((LA24_0>='\u0000' && LA24_0<='\t')||(LA24_0>='\u000B' && LA24_0<='\f')||(LA24_0>='\u000E' && LA24_0<='/')||(LA24_0>=':' && LA24_0<='t')||(LA24_0>='v' && LA24_0<='w')||(LA24_0>='y' && LA24_0<='\u2027')||(LA24_0>='\u202A' && LA24_0<='\uFFFF')))
			{
				alt24=1;
			}
			else if (((LA24_0>='0' && LA24_0<='7')))
			{
				alt24=2;
			}
			else if ((LA24_0=='x'))
			{
				alt24=3;
			}
			else if ((LA24_0=='u'))
			{
				alt24=4;
			}
			else if ((LA24_0=='\n'||LA24_0=='\r'))
			{
				alt24=5;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 24, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(24); }
			switch (alt24)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:941:3: CharacterEscapeSequence
				{
				DebugLocation(941, 3);
				mCharacterEscapeSequence(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:942:5: OctalEscapeSequence
				{
				DebugLocation(942, 5);
				mOctalEscapeSequence(); 

				}
				break;
			case 3:
				DebugEnterAlt(3);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:943:5: HexEscapeSequence
				{
				DebugLocation(943, 5);
				mHexEscapeSequence(); 

				}
				break;
			case 4:
				DebugEnterAlt(4);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:944:5: UnicodeEscapeSequence
				{
				DebugLocation(944, 5);
				mUnicodeEscapeSequence(); 

				}
				break;
			case 5:
				DebugEnterAlt(5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:945:5: ( CR )? LF
				{
				DebugLocation(945, 5);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:945:5: ( CR )?
				int alt23=2;
				try { DebugEnterSubRule(23);
				try { DebugEnterDecision(23, decisionCanBacktrack[23]);
				int LA23_0 = input.LA(1);

				if ((LA23_0=='\r'))
				{
					alt23=1;
				}
				} finally { DebugExitDecision(23); }
				switch (alt23)
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:
					{
					DebugLocation(945, 5);
					input.Consume();


					}
					break;

				}
				} finally { DebugExitSubRule(23); }

				DebugLocation(945, 9);
				mLF(); 

				}
				break;

			}
			} finally { DebugExitSubRule(24); }


			}

		}
		finally
		{
			TraceOut("EscapeSequence", 143);
			LeaveRule("EscapeSequence", 143);
			Leave_EscapeSequence();
		}
	}
	// $ANTLR end "EscapeSequence"

	partial void Enter_StringLiteral();
	partial void Leave_StringLiteral();

	// $ANTLR start "StringLiteral"
	[GrammarRule("StringLiteral")]
	private void mStringLiteral()
	{
		Enter_StringLiteral();
		EnterRule("StringLiteral", 144);
		TraceIn("StringLiteral", 144);
		try
		{
			int _type = StringLiteral;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:950:2: ( SQUOTE (~ ( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* SQUOTE | DQUOTE (~ ( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* DQUOTE )
			int alt27=2;
			try { DebugEnterDecision(27, decisionCanBacktrack[27]);
			int LA27_0 = input.LA(1);

			if ((LA27_0=='\''))
			{
				alt27=1;
			}
			else if ((LA27_0=='\"'))
			{
				alt27=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 27, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(27); }
			switch (alt27)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:950:4: SQUOTE (~ ( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* SQUOTE
				{
				DebugLocation(950, 4);
				mSQUOTE(); 
				DebugLocation(950, 11);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:950:11: (~ ( SQUOTE | BSLASH | LineTerminator ) | EscapeSequence )*
				try { DebugEnterSubRule(25);
				while (true)
				{
					int alt25=3;
					try { DebugEnterDecision(25, decisionCanBacktrack[25]);
					int LA25_0 = input.LA(1);

					if (((LA25_0>='\u0000' && LA25_0<='\t')||(LA25_0>='\u000B' && LA25_0<='\f')||(LA25_0>='\u000E' && LA25_0<='&')||(LA25_0>='(' && LA25_0<='[')||(LA25_0>=']' && LA25_0<='\u2027')||(LA25_0>='\u202A' && LA25_0<='\uFFFF')))
					{
						alt25=1;
					}
					else if ((LA25_0=='\\'))
					{
						alt25=2;
					}


					} finally { DebugExitDecision(25); }
					switch ( alt25 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:950:13: ~ ( SQUOTE | BSLASH | LineTerminator )
						{
						DebugLocation(950, 13);
						input.Consume();


						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:950:53: EscapeSequence
						{
						DebugLocation(950, 53);
						mEscapeSequence(); 

						}
						break;

					default:
						goto loop25;
					}
				}

				loop25:
					;

				} finally { DebugExitSubRule(25); }

				DebugLocation(950, 71);
				mSQUOTE(); 

				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:951:4: DQUOTE (~ ( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )* DQUOTE
				{
				DebugLocation(951, 4);
				mDQUOTE(); 
				DebugLocation(951, 11);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:951:11: (~ ( DQUOTE | BSLASH | LineTerminator ) | EscapeSequence )*
				try { DebugEnterSubRule(26);
				while (true)
				{
					int alt26=3;
					try { DebugEnterDecision(26, decisionCanBacktrack[26]);
					int LA26_0 = input.LA(1);

					if (((LA26_0>='\u0000' && LA26_0<='\t')||(LA26_0>='\u000B' && LA26_0<='\f')||(LA26_0>='\u000E' && LA26_0<='!')||(LA26_0>='#' && LA26_0<='[')||(LA26_0>=']' && LA26_0<='\u2027')||(LA26_0>='\u202A' && LA26_0<='\uFFFF')))
					{
						alt26=1;
					}
					else if ((LA26_0=='\\'))
					{
						alt26=2;
					}


					} finally { DebugExitDecision(26); }
					switch ( alt26 )
					{
					case 1:
						DebugEnterAlt(1);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:951:13: ~ ( DQUOTE | BSLASH | LineTerminator )
						{
						DebugLocation(951, 13);
						input.Consume();


						}
						break;
					case 2:
						DebugEnterAlt(2);
						// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:951:53: EscapeSequence
						{
						DebugLocation(951, 53);
						mEscapeSequence(); 

						}
						break;

					default:
						goto loop26;
					}
				}

				loop26:
					;

				} finally { DebugExitSubRule(26); }

				DebugLocation(951, 71);
				mDQUOTE(); 

				}
				break;

			}
			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("StringLiteral", 144);
			LeaveRule("StringLiteral", 144);
			Leave_StringLiteral();
		}
	}
	// $ANTLR end "StringLiteral"

	partial void Enter_BackslashSequence();
	partial void Leave_BackslashSequence();

	// $ANTLR start "BackslashSequence"
	[GrammarRule("BackslashSequence")]
	private void mBackslashSequence()
	{
		Enter_BackslashSequence();
		EnterRule("BackslashSequence", 145);
		TraceIn("BackslashSequence", 145);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:959:2: ( BSLASH ~ ( LineTerminator ) )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:959:4: BSLASH ~ ( LineTerminator )
			{
			DebugLocation(959, 4);
			mBSLASH(); 
			DebugLocation(959, 11);
			if ((input.LA(1)>='\u0000' && input.LA(1)<='\t')||(input.LA(1)>='\u000B' && input.LA(1)<='\f')||(input.LA(1)>='\u000E' && input.LA(1)<='\u2027')||(input.LA(1)>='\u202A' && input.LA(1)<='\uFFFF'))
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				DebugRecognitionException(mse);
				Recover(mse);
				throw mse;}


			}

		}
		finally
		{
			TraceOut("BackslashSequence", 145);
			LeaveRule("BackslashSequence", 145);
			Leave_BackslashSequence();
		}
	}
	// $ANTLR end "BackslashSequence"

	partial void Enter_RegularExpressionFirstChar();
	partial void Leave_RegularExpressionFirstChar();

	// $ANTLR start "RegularExpressionFirstChar"
	[GrammarRule("RegularExpressionFirstChar")]
	private void mRegularExpressionFirstChar()
	{
		Enter_RegularExpressionFirstChar();
		EnterRule("RegularExpressionFirstChar", 146);
		TraceIn("RegularExpressionFirstChar", 146);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:963:2: (~ ( LineTerminator | MUL | BSLASH | DIV ) | BackslashSequence )
			int alt28=2;
			try { DebugEnterDecision(28, decisionCanBacktrack[28]);
			int LA28_0 = input.LA(1);

			if (((LA28_0>='\u0000' && LA28_0<='\t')||(LA28_0>='\u000B' && LA28_0<='\f')||(LA28_0>='\u000E' && LA28_0<=')')||(LA28_0>='+' && LA28_0<='.')||(LA28_0>='0' && LA28_0<='[')||(LA28_0>=']' && LA28_0<='\u2027')||(LA28_0>='\u202A' && LA28_0<='\uFFFF')))
			{
				alt28=1;
			}
			else if ((LA28_0=='\\'))
			{
				alt28=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 28, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(28); }
			switch (alt28)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:963:4: ~ ( LineTerminator | MUL | BSLASH | DIV )
				{
				DebugLocation(963, 4);
				input.Consume();


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:964:4: BackslashSequence
				{
				DebugLocation(964, 4);
				mBackslashSequence(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("RegularExpressionFirstChar", 146);
			LeaveRule("RegularExpressionFirstChar", 146);
			Leave_RegularExpressionFirstChar();
		}
	}
	// $ANTLR end "RegularExpressionFirstChar"

	partial void Enter_RegularExpressionChar();
	partial void Leave_RegularExpressionChar();

	// $ANTLR start "RegularExpressionChar"
	[GrammarRule("RegularExpressionChar")]
	private void mRegularExpressionChar()
	{
		Enter_RegularExpressionChar();
		EnterRule("RegularExpressionChar", 147);
		TraceIn("RegularExpressionChar", 147);
		try
		{
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:968:2: (~ ( LineTerminator | BSLASH | DIV ) | BackslashSequence )
			int alt29=2;
			try { DebugEnterDecision(29, decisionCanBacktrack[29]);
			int LA29_0 = input.LA(1);

			if (((LA29_0>='\u0000' && LA29_0<='\t')||(LA29_0>='\u000B' && LA29_0<='\f')||(LA29_0>='\u000E' && LA29_0<='.')||(LA29_0>='0' && LA29_0<='[')||(LA29_0>=']' && LA29_0<='\u2027')||(LA29_0>='\u202A' && LA29_0<='\uFFFF')))
			{
				alt29=1;
			}
			else if ((LA29_0=='\\'))
			{
				alt29=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 29, 0, input);

				DebugRecognitionException(nvae);
				throw nvae;
			}
			} finally { DebugExitDecision(29); }
			switch (alt29)
			{
			case 1:
				DebugEnterAlt(1);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:968:4: ~ ( LineTerminator | BSLASH | DIV )
				{
				DebugLocation(968, 4);
				input.Consume();


				}
				break;
			case 2:
				DebugEnterAlt(2);
				// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:969:4: BackslashSequence
				{
				DebugLocation(969, 4);
				mBackslashSequence(); 

				}
				break;

			}
		}
		finally
		{
			TraceOut("RegularExpressionChar", 147);
			LeaveRule("RegularExpressionChar", 147);
			Leave_RegularExpressionChar();
		}
	}
	// $ANTLR end "RegularExpressionChar"

	partial void Enter_RegularExpressionLiteral();
	partial void Leave_RegularExpressionLiteral();

	// $ANTLR start "RegularExpressionLiteral"
	[GrammarRule("RegularExpressionLiteral")]
	private void mRegularExpressionLiteral()
	{
		Enter_RegularExpressionLiteral();
		EnterRule("RegularExpressionLiteral", 148);
		TraceIn("RegularExpressionLiteral", 148);
		try
		{
			int _type = RegularExpressionLiteral;
			int _channel = DefaultTokenChannel;
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:973:2: ({...}? => DIV RegularExpressionFirstChar ( RegularExpressionChar )* DIV ( IdentifierPart )* )
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:973:4: {...}? => DIV RegularExpressionFirstChar ( RegularExpressionChar )* DIV ( IdentifierPart )*
			{
			DebugLocation(973, 4);
			if (!(( AreRegularExpressionsEnabled() )))
			{
				throw new FailedPredicateException(input, "RegularExpressionLiteral", " AreRegularExpressionsEnabled() ");
			}
			DebugLocation(973, 42);
			mDIV(); 
			DebugLocation(973, 46);
			mRegularExpressionFirstChar(); 
			DebugLocation(973, 73);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:973:73: ( RegularExpressionChar )*
			try { DebugEnterSubRule(30);
			while (true)
			{
				int alt30=2;
				try { DebugEnterDecision(30, decisionCanBacktrack[30]);
				int LA30_0 = input.LA(1);

				if (((LA30_0>='\u0000' && LA30_0<='\t')||(LA30_0>='\u000B' && LA30_0<='\f')||(LA30_0>='\u000E' && LA30_0<='.')||(LA30_0>='0' && LA30_0<='\u2027')||(LA30_0>='\u202A' && LA30_0<='\uFFFF')))
				{
					alt30=1;
				}


				} finally { DebugExitDecision(30); }
				switch ( alt30 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:973:73: RegularExpressionChar
					{
					DebugLocation(973, 73);
					mRegularExpressionChar(); 

					}
					break;

				default:
					goto loop30;
				}
			}

			loop30:
				;

			} finally { DebugExitSubRule(30); }

			DebugLocation(973, 96);
			mDIV(); 
			DebugLocation(973, 100);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:973:100: ( IdentifierPart )*
			try { DebugEnterSubRule(31);
			while (true)
			{
				int alt31=2;
				try { DebugEnterDecision(31, decisionCanBacktrack[31]);
				int LA31_0 = input.LA(1);

				if ((LA31_0=='$'||(LA31_0>='0' && LA31_0<='9')||(LA31_0>='A' && LA31_0<='Z')||LA31_0=='\\'||LA31_0=='_'||(LA31_0>='a' && LA31_0<='z')))
				{
					alt31=1;
				}
				else if ((( IsIdentifierPartUnicode(input.LA(1)) )))
				{
					alt31=1;
				}


				} finally { DebugExitDecision(31); }
				switch ( alt31 )
				{
				case 1:
					DebugEnterAlt(1);
					// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:973:100: IdentifierPart
					{
					DebugLocation(973, 100);
					mIdentifierPart(); 

					}
					break;

				default:
					goto loop31;
				}
			}

			loop31:
				;

			} finally { DebugExitSubRule(31); }


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
			TraceOut("RegularExpressionLiteral", 148);
			LeaveRule("RegularExpressionLiteral", 148);
			Leave_RegularExpressionLiteral();
		}
	}
	// $ANTLR end "RegularExpressionLiteral"

	public override void mTokens()
	{
		// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:8: ( ABSTRACT | ADD | ADDASS | AND | ANDASS | ASSIGN | BOOLEAN | BREAK | BYTE | CASE | CATCH | CHAR | CLASS | COLON | COMMA | CONST | CONTINUE | DEBUGGER | DEC | DEFAULT | DELETE | DIV | DIVASS | DO | DOT | DOUBLE | ELSE | ENUM | EQ | EXPORT | EXTENDS | FALSE | FINAL | FINALLY | FLOAT | FOR | FUNCTION | GOTO | GT | GTE | IF | IMPLEMENTS | IMPORT | IN | INC | INSTANCEOF | INT | INTERFACE | INV | LAND | LBRACE | LBRACK | LONG | LOR | LPAREN | LT | LTE | MOD | MODASS | MUL | MULASS | NATIVE | NEQ | NEW | NOT | NSAME | NULL | OR | ORASS | PACKAGE | PRIVATE | PROTECTED | PUBLIC | QUE | RBRACE | RBRACK | RETURN | RPAREN | SAME | SEMIC | SHL | SHLASS | SHORT | SHR | SHRASS | SHU | SHUASS | STATIC | SUB | SUBASS | SUPER | SWITCH | SYNCHRONIZED | THIS | THROW | THROWS | TRANSIENT | TRUE | TRY | TYPEOF | VAR | VOID | VOLATILE | WHILE | WITH | XOR | XORASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral )
		int alt32=117;
		try { DebugEnterDecision(32, decisionCanBacktrack[32]);
		try
		{
			alt32 = dfa32.Predict(input);
		}
		catch (NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
			throw;
		}
		} finally { DebugExitDecision(32); }
		switch (alt32)
		{
		case 1:
			DebugEnterAlt(1);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:10: ABSTRACT
			{
			DebugLocation(1, 10);
			mABSTRACT(); 

			}
			break;
		case 2:
			DebugEnterAlt(2);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:19: ADD
			{
			DebugLocation(1, 19);
			mADD(); 

			}
			break;
		case 3:
			DebugEnterAlt(3);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:23: ADDASS
			{
			DebugLocation(1, 23);
			mADDASS(); 

			}
			break;
		case 4:
			DebugEnterAlt(4);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:30: AND
			{
			DebugLocation(1, 30);
			mAND(); 

			}
			break;
		case 5:
			DebugEnterAlt(5);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:34: ANDASS
			{
			DebugLocation(1, 34);
			mANDASS(); 

			}
			break;
		case 6:
			DebugEnterAlt(6);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:41: ASSIGN
			{
			DebugLocation(1, 41);
			mASSIGN(); 

			}
			break;
		case 7:
			DebugEnterAlt(7);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:48: BOOLEAN
			{
			DebugLocation(1, 48);
			mBOOLEAN(); 

			}
			break;
		case 8:
			DebugEnterAlt(8);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:56: BREAK
			{
			DebugLocation(1, 56);
			mBREAK(); 

			}
			break;
		case 9:
			DebugEnterAlt(9);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:62: BYTE
			{
			DebugLocation(1, 62);
			mBYTE(); 

			}
			break;
		case 10:
			DebugEnterAlt(10);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:67: CASE
			{
			DebugLocation(1, 67);
			mCASE(); 

			}
			break;
		case 11:
			DebugEnterAlt(11);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:72: CATCH
			{
			DebugLocation(1, 72);
			mCATCH(); 

			}
			break;
		case 12:
			DebugEnterAlt(12);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:78: CHAR
			{
			DebugLocation(1, 78);
			mCHAR(); 

			}
			break;
		case 13:
			DebugEnterAlt(13);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:83: CLASS
			{
			DebugLocation(1, 83);
			mCLASS(); 

			}
			break;
		case 14:
			DebugEnterAlt(14);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:89: COLON
			{
			DebugLocation(1, 89);
			mCOLON(); 

			}
			break;
		case 15:
			DebugEnterAlt(15);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:95: COMMA
			{
			DebugLocation(1, 95);
			mCOMMA(); 

			}
			break;
		case 16:
			DebugEnterAlt(16);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:101: CONST
			{
			DebugLocation(1, 101);
			mCONST(); 

			}
			break;
		case 17:
			DebugEnterAlt(17);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:107: CONTINUE
			{
			DebugLocation(1, 107);
			mCONTINUE(); 

			}
			break;
		case 18:
			DebugEnterAlt(18);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:116: DEBUGGER
			{
			DebugLocation(1, 116);
			mDEBUGGER(); 

			}
			break;
		case 19:
			DebugEnterAlt(19);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:125: DEC
			{
			DebugLocation(1, 125);
			mDEC(); 

			}
			break;
		case 20:
			DebugEnterAlt(20);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:129: DEFAULT
			{
			DebugLocation(1, 129);
			mDEFAULT(); 

			}
			break;
		case 21:
			DebugEnterAlt(21);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:137: DELETE
			{
			DebugLocation(1, 137);
			mDELETE(); 

			}
			break;
		case 22:
			DebugEnterAlt(22);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:144: DIV
			{
			DebugLocation(1, 144);
			mDIV(); 

			}
			break;
		case 23:
			DebugEnterAlt(23);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:148: DIVASS
			{
			DebugLocation(1, 148);
			mDIVASS(); 

			}
			break;
		case 24:
			DebugEnterAlt(24);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:155: DO
			{
			DebugLocation(1, 155);
			mDO(); 

			}
			break;
		case 25:
			DebugEnterAlt(25);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:158: DOT
			{
			DebugLocation(1, 158);
			mDOT(); 

			}
			break;
		case 26:
			DebugEnterAlt(26);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:162: DOUBLE
			{
			DebugLocation(1, 162);
			mDOUBLE(); 

			}
			break;
		case 27:
			DebugEnterAlt(27);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:169: ELSE
			{
			DebugLocation(1, 169);
			mELSE(); 

			}
			break;
		case 28:
			DebugEnterAlt(28);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:174: ENUM
			{
			DebugLocation(1, 174);
			mENUM(); 

			}
			break;
		case 29:
			DebugEnterAlt(29);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:179: EQ
			{
			DebugLocation(1, 179);
			mEQ(); 

			}
			break;
		case 30:
			DebugEnterAlt(30);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:182: EXPORT
			{
			DebugLocation(1, 182);
			mEXPORT(); 

			}
			break;
		case 31:
			DebugEnterAlt(31);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:189: EXTENDS
			{
			DebugLocation(1, 189);
			mEXTENDS(); 

			}
			break;
		case 32:
			DebugEnterAlt(32);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:197: FALSE
			{
			DebugLocation(1, 197);
			mFALSE(); 

			}
			break;
		case 33:
			DebugEnterAlt(33);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:203: FINAL
			{
			DebugLocation(1, 203);
			mFINAL(); 

			}
			break;
		case 34:
			DebugEnterAlt(34);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:209: FINALLY
			{
			DebugLocation(1, 209);
			mFINALLY(); 

			}
			break;
		case 35:
			DebugEnterAlt(35);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:217: FLOAT
			{
			DebugLocation(1, 217);
			mFLOAT(); 

			}
			break;
		case 36:
			DebugEnterAlt(36);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:223: FOR
			{
			DebugLocation(1, 223);
			mFOR(); 

			}
			break;
		case 37:
			DebugEnterAlt(37);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:227: FUNCTION
			{
			DebugLocation(1, 227);
			mFUNCTION(); 

			}
			break;
		case 38:
			DebugEnterAlt(38);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:236: GOTO
			{
			DebugLocation(1, 236);
			mGOTO(); 

			}
			break;
		case 39:
			DebugEnterAlt(39);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:241: GT
			{
			DebugLocation(1, 241);
			mGT(); 

			}
			break;
		case 40:
			DebugEnterAlt(40);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:244: GTE
			{
			DebugLocation(1, 244);
			mGTE(); 

			}
			break;
		case 41:
			DebugEnterAlt(41);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:248: IF
			{
			DebugLocation(1, 248);
			mIF(); 

			}
			break;
		case 42:
			DebugEnterAlt(42);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:251: IMPLEMENTS
			{
			DebugLocation(1, 251);
			mIMPLEMENTS(); 

			}
			break;
		case 43:
			DebugEnterAlt(43);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:262: IMPORT
			{
			DebugLocation(1, 262);
			mIMPORT(); 

			}
			break;
		case 44:
			DebugEnterAlt(44);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:269: IN
			{
			DebugLocation(1, 269);
			mIN(); 

			}
			break;
		case 45:
			DebugEnterAlt(45);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:272: INC
			{
			DebugLocation(1, 272);
			mINC(); 

			}
			break;
		case 46:
			DebugEnterAlt(46);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:276: INSTANCEOF
			{
			DebugLocation(1, 276);
			mINSTANCEOF(); 

			}
			break;
		case 47:
			DebugEnterAlt(47);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:287: INT
			{
			DebugLocation(1, 287);
			mINT(); 

			}
			break;
		case 48:
			DebugEnterAlt(48);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:291: INTERFACE
			{
			DebugLocation(1, 291);
			mINTERFACE(); 

			}
			break;
		case 49:
			DebugEnterAlt(49);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:301: INV
			{
			DebugLocation(1, 301);
			mINV(); 

			}
			break;
		case 50:
			DebugEnterAlt(50);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:305: LAND
			{
			DebugLocation(1, 305);
			mLAND(); 

			}
			break;
		case 51:
			DebugEnterAlt(51);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:310: LBRACE
			{
			DebugLocation(1, 310);
			mLBRACE(); 

			}
			break;
		case 52:
			DebugEnterAlt(52);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:317: LBRACK
			{
			DebugLocation(1, 317);
			mLBRACK(); 

			}
			break;
		case 53:
			DebugEnterAlt(53);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:324: LONG
			{
			DebugLocation(1, 324);
			mLONG(); 

			}
			break;
		case 54:
			DebugEnterAlt(54);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:329: LOR
			{
			DebugLocation(1, 329);
			mLOR(); 

			}
			break;
		case 55:
			DebugEnterAlt(55);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:333: LPAREN
			{
			DebugLocation(1, 333);
			mLPAREN(); 

			}
			break;
		case 56:
			DebugEnterAlt(56);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:340: LT
			{
			DebugLocation(1, 340);
			mLT(); 

			}
			break;
		case 57:
			DebugEnterAlt(57);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:343: LTE
			{
			DebugLocation(1, 343);
			mLTE(); 

			}
			break;
		case 58:
			DebugEnterAlt(58);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:347: MOD
			{
			DebugLocation(1, 347);
			mMOD(); 

			}
			break;
		case 59:
			DebugEnterAlt(59);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:351: MODASS
			{
			DebugLocation(1, 351);
			mMODASS(); 

			}
			break;
		case 60:
			DebugEnterAlt(60);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:358: MUL
			{
			DebugLocation(1, 358);
			mMUL(); 

			}
			break;
		case 61:
			DebugEnterAlt(61);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:362: MULASS
			{
			DebugLocation(1, 362);
			mMULASS(); 

			}
			break;
		case 62:
			DebugEnterAlt(62);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:369: NATIVE
			{
			DebugLocation(1, 369);
			mNATIVE(); 

			}
			break;
		case 63:
			DebugEnterAlt(63);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:376: NEQ
			{
			DebugLocation(1, 376);
			mNEQ(); 

			}
			break;
		case 64:
			DebugEnterAlt(64);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:380: NEW
			{
			DebugLocation(1, 380);
			mNEW(); 

			}
			break;
		case 65:
			DebugEnterAlt(65);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:384: NOT
			{
			DebugLocation(1, 384);
			mNOT(); 

			}
			break;
		case 66:
			DebugEnterAlt(66);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:388: NSAME
			{
			DebugLocation(1, 388);
			mNSAME(); 

			}
			break;
		case 67:
			DebugEnterAlt(67);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:394: NULL
			{
			DebugLocation(1, 394);
			mNULL(); 

			}
			break;
		case 68:
			DebugEnterAlt(68);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:399: OR
			{
			DebugLocation(1, 399);
			mOR(); 

			}
			break;
		case 69:
			DebugEnterAlt(69);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:402: ORASS
			{
			DebugLocation(1, 402);
			mORASS(); 

			}
			break;
		case 70:
			DebugEnterAlt(70);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:408: PACKAGE
			{
			DebugLocation(1, 408);
			mPACKAGE(); 

			}
			break;
		case 71:
			DebugEnterAlt(71);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:416: PRIVATE
			{
			DebugLocation(1, 416);
			mPRIVATE(); 

			}
			break;
		case 72:
			DebugEnterAlt(72);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:424: PROTECTED
			{
			DebugLocation(1, 424);
			mPROTECTED(); 

			}
			break;
		case 73:
			DebugEnterAlt(73);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:434: PUBLIC
			{
			DebugLocation(1, 434);
			mPUBLIC(); 

			}
			break;
		case 74:
			DebugEnterAlt(74);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:441: QUE
			{
			DebugLocation(1, 441);
			mQUE(); 

			}
			break;
		case 75:
			DebugEnterAlt(75);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:445: RBRACE
			{
			DebugLocation(1, 445);
			mRBRACE(); 

			}
			break;
		case 76:
			DebugEnterAlt(76);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:452: RBRACK
			{
			DebugLocation(1, 452);
			mRBRACK(); 

			}
			break;
		case 77:
			DebugEnterAlt(77);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:459: RETURN
			{
			DebugLocation(1, 459);
			mRETURN(); 

			}
			break;
		case 78:
			DebugEnterAlt(78);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:466: RPAREN
			{
			DebugLocation(1, 466);
			mRPAREN(); 

			}
			break;
		case 79:
			DebugEnterAlt(79);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:473: SAME
			{
			DebugLocation(1, 473);
			mSAME(); 

			}
			break;
		case 80:
			DebugEnterAlt(80);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:478: SEMIC
			{
			DebugLocation(1, 478);
			mSEMIC(); 

			}
			break;
		case 81:
			DebugEnterAlt(81);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:484: SHL
			{
			DebugLocation(1, 484);
			mSHL(); 

			}
			break;
		case 82:
			DebugEnterAlt(82);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:488: SHLASS
			{
			DebugLocation(1, 488);
			mSHLASS(); 

			}
			break;
		case 83:
			DebugEnterAlt(83);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:495: SHORT
			{
			DebugLocation(1, 495);
			mSHORT(); 

			}
			break;
		case 84:
			DebugEnterAlt(84);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:501: SHR
			{
			DebugLocation(1, 501);
			mSHR(); 

			}
			break;
		case 85:
			DebugEnterAlt(85);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:505: SHRASS
			{
			DebugLocation(1, 505);
			mSHRASS(); 

			}
			break;
		case 86:
			DebugEnterAlt(86);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:512: SHU
			{
			DebugLocation(1, 512);
			mSHU(); 

			}
			break;
		case 87:
			DebugEnterAlt(87);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:516: SHUASS
			{
			DebugLocation(1, 516);
			mSHUASS(); 

			}
			break;
		case 88:
			DebugEnterAlt(88);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:523: STATIC
			{
			DebugLocation(1, 523);
			mSTATIC(); 

			}
			break;
		case 89:
			DebugEnterAlt(89);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:530: SUB
			{
			DebugLocation(1, 530);
			mSUB(); 

			}
			break;
		case 90:
			DebugEnterAlt(90);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:534: SUBASS
			{
			DebugLocation(1, 534);
			mSUBASS(); 

			}
			break;
		case 91:
			DebugEnterAlt(91);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:541: SUPER
			{
			DebugLocation(1, 541);
			mSUPER(); 

			}
			break;
		case 92:
			DebugEnterAlt(92);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:547: SWITCH
			{
			DebugLocation(1, 547);
			mSWITCH(); 

			}
			break;
		case 93:
			DebugEnterAlt(93);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:554: SYNCHRONIZED
			{
			DebugLocation(1, 554);
			mSYNCHRONIZED(); 

			}
			break;
		case 94:
			DebugEnterAlt(94);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:567: THIS
			{
			DebugLocation(1, 567);
			mTHIS(); 

			}
			break;
		case 95:
			DebugEnterAlt(95);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:572: THROW
			{
			DebugLocation(1, 572);
			mTHROW(); 

			}
			break;
		case 96:
			DebugEnterAlt(96);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:578: THROWS
			{
			DebugLocation(1, 578);
			mTHROWS(); 

			}
			break;
		case 97:
			DebugEnterAlt(97);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:585: TRANSIENT
			{
			DebugLocation(1, 585);
			mTRANSIENT(); 

			}
			break;
		case 98:
			DebugEnterAlt(98);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:595: TRUE
			{
			DebugLocation(1, 595);
			mTRUE(); 

			}
			break;
		case 99:
			DebugEnterAlt(99);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:600: TRY
			{
			DebugLocation(1, 600);
			mTRY(); 

			}
			break;
		case 100:
			DebugEnterAlt(100);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:604: TYPEOF
			{
			DebugLocation(1, 604);
			mTYPEOF(); 

			}
			break;
		case 101:
			DebugEnterAlt(101);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:611: VAR
			{
			DebugLocation(1, 611);
			mVAR(); 

			}
			break;
		case 102:
			DebugEnterAlt(102);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:615: VOID
			{
			DebugLocation(1, 615);
			mVOID(); 

			}
			break;
		case 103:
			DebugEnterAlt(103);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:620: VOLATILE
			{
			DebugLocation(1, 620);
			mVOLATILE(); 

			}
			break;
		case 104:
			DebugEnterAlt(104);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:629: WHILE
			{
			DebugLocation(1, 629);
			mWHILE(); 

			}
			break;
		case 105:
			DebugEnterAlt(105);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:635: WITH
			{
			DebugLocation(1, 635);
			mWITH(); 

			}
			break;
		case 106:
			DebugEnterAlt(106);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:640: XOR
			{
			DebugLocation(1, 640);
			mXOR(); 

			}
			break;
		case 107:
			DebugEnterAlt(107);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:644: XORASS
			{
			DebugLocation(1, 644);
			mXORASS(); 

			}
			break;
		case 108:
			DebugEnterAlt(108);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:651: WhiteSpace
			{
			DebugLocation(1, 651);
			mWhiteSpace(); 

			}
			break;
		case 109:
			DebugEnterAlt(109);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:662: EOL
			{
			DebugLocation(1, 662);
			mEOL(); 

			}
			break;
		case 110:
			DebugEnterAlt(110);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:666: MultiLineComment
			{
			DebugLocation(1, 666);
			mMultiLineComment(); 

			}
			break;
		case 111:
			DebugEnterAlt(111);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:683: SingleLineComment
			{
			DebugLocation(1, 683);
			mSingleLineComment(); 

			}
			break;
		case 112:
			DebugEnterAlt(112);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:701: Identifier
			{
			DebugLocation(1, 701);
			mIdentifier(); 

			}
			break;
		case 113:
			DebugEnterAlt(113);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:712: DecimalLiteral
			{
			DebugLocation(1, 712);
			mDecimalLiteral(); 

			}
			break;
		case 114:
			DebugEnterAlt(114);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:727: OctalIntegerLiteral
			{
			DebugLocation(1, 727);
			mOctalIntegerLiteral(); 

			}
			break;
		case 115:
			DebugEnterAlt(115);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:747: HexIntegerLiteral
			{
			DebugLocation(1, 747);
			mHexIntegerLiteral(); 

			}
			break;
		case 116:
			DebugEnterAlt(116);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:765: StringLiteral
			{
			DebugLocation(1, 765);
			mStringLiteral(); 

			}
			break;
		case 117:
			DebugEnterAlt(117);
			// C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g:1:779: RegularExpressionLiteral
			{
			DebugLocation(1, 779);
			mRegularExpressionLiteral(); 

			}
			break;

		}

	}


	#region DFA
	DFA18 dfa18;
	DFA32 dfa32;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa18 = new DFA18(this);
		dfa32 = new DFA32(this, SpecialStateTransition32);
	}

	private class DFA18 : DFA
	{
		private const string DFA18_eotS =
			"\x1\xFFFF\x2\x4\x3\xFFFF\x1\x4";
		private const string DFA18_eofS =
			"\x7\xFFFF";
		private const string DFA18_minS =
			"\x3\x2E\x3\xFFFF\x1\x2E";
		private const string DFA18_maxS =
			"\x1\x39\x1\x2E\x1\x39\x3\xFFFF\x1\x39";
		private const string DFA18_acceptS =
			"\x3\xFFFF\x1\x2\x1\x3\x1\x1\x1\xFFFF";
		private const string DFA18_specialS =
			"\x7\xFFFF}>";
		private static readonly string[] DFA18_transitionS =
			{
				"\x1\x3\x1\xFFFF\x1\x1\x9\x2",
				"\x1\x5",
				"\x1\x5\x1\xFFFF\xA\x6",
				"",
				"",
				"",
				"\x1\x5\x1\xFFFF\xA\x6"
			};

		private static readonly short[] DFA18_eot = DFA.UnpackEncodedString(DFA18_eotS);
		private static readonly short[] DFA18_eof = DFA.UnpackEncodedString(DFA18_eofS);
		private static readonly char[] DFA18_min = DFA.UnpackEncodedStringToUnsignedChars(DFA18_minS);
		private static readonly char[] DFA18_max = DFA.UnpackEncodedStringToUnsignedChars(DFA18_maxS);
		private static readonly short[] DFA18_accept = DFA.UnpackEncodedString(DFA18_acceptS);
		private static readonly short[] DFA18_special = DFA.UnpackEncodedString(DFA18_specialS);
		private static readonly short[][] DFA18_transition;

		static DFA18()
		{
			int numStates = DFA18_transitionS.Length;
			DFA18_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA18_transition[i] = DFA.UnpackEncodedString(DFA18_transitionS[i]);
			}
		}

		public DFA18( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 18;
			this.eot = DFA18_eot;
			this.eof = DFA18_eof;
			this.min = DFA18_min;
			this.max = DFA18_max;
			this.accept = DFA18_accept;
			this.special = DFA18_special;
			this.transition = DFA18_transition;
		}

		public override string Description { get { return "885:1: DecimalLiteral : ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | DecimalIntegerLiteral ( ExponentPart )? );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private class DFA32 : DFA
	{
		private const string DFA32_eotS =
			"\x2\x2B\x1\x32\x1\x35\x1\x37\x2\x2B\x2\xFFFF\x1\x2B\x1\x43\x1\x47\x1"+
			"\x49\x3\x2B\x1\x55\x1\x2B\x3\xFFFF\x1\x2B\x1\x5C\x1\xFFFF\x1\x5F\x1\x61"+
			"\x1\x63\x1\x2B\x1\x68\x1\x2B\x3\xFFFF\x1\x2B\x2\xFFFF\x4\x2B\x1\x7A\x3"+
			"\xFFFF\x1\x2D\x2\xFFFF\x1\x2B\x6\xFFFF\x1\x7F\x1\xFFFF\x8\x2B\x1\x8C"+
			"\x3\xFFFF\x1\x8D\x5\xFFFF\x9\x2B\x1\xFFFF\x1\x9A\x1\xFFFF\x1\x9B\x1\x2B"+
			"\x1\x9F\x1\x2B\x4\xFFFF\x1\xA2\x5\xFFFF\x3\x2B\x1\xA7\x1\xFFFF\x10\x2B"+
			"\x4\xFFFF\x1\x2B\x2\xFFFF\xC\x2B\x2\xFFFF\x7\x2B\x1\xD2\x2\x2B\x1\xFFFF"+
			"\x1\xD6\x2\xFFFF\x2\x2B\x1\xDB\x1\xFFFF\x1\x2B\x2\xFFFF\x1\x2B\x1\xDE"+
			"\x1\x2B\x2\xFFFF\xE\x2B\x1\xEE\x1\x2B\x1\xF0\x7\x2B\x1\xF8\x1\xF9\x1"+
			"\x2B\x1\xFB\x7\x2B\x1\x103\x1\x104\x5\x2B\x1\xFFFF\x1\x2B\x1\x10B\x2"+
			"\xFFFF\x4\x2B\x1\xFFFF\x1\x110\x1\x2B\x1\xFFFF\x1\x112\xA\x2B\x1\x11D"+
			"\x2\x2B\x1\x120\x1\xFFFF\x1\x2B\x1\xFFFF\x1\x122\x2\x2B\x1\x125\x2\x2B"+
			"\x1\x128\x2\xFFFF\x1\x129\x1\xFFFF\x1\x12A\x1\x12B\x5\x2B\x2\xFFFF\x2"+
			"\x2B\x1\x133\x1\x135\x1\x136\x1\x2B\x1\xFFFF\x4\x2B\x1\xFFFF\x1\x2B\x1"+
			"\xFFFF\x5\x2B\x1\x142\x1\x2B\x1\x144\x2\x2B\x1\xFFFF\x1\x148\x1\x2B\x1"+
			"\xFFFF\x1\x2B\x1\xFFFF\x1\x2B\x1\x14C\x1\xFFFF\x2\x2B\x4\xFFFF\x3\x2B"+
			"\x1\x152\x1\x153\x1\x154\x1\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x2\x2B\x1\x159"+
			"\x2\x2B\x1\x15C\x3\x2B\x1\x160\x1\x161\x1\xFFFF\x1\x162\x1\xFFFF\x1\x163"+
			"\x1\x2B\x1\x165\x1\xFFFF\x1\x2B\x1\x167\x1\x2B\x1\xFFFF\x1\x2B\x1\x16A"+
			"\x2\x2B\x1\x16D\x3\xFFFF\x1\x16E\x1\x16F\x2\x2B\x1\xFFFF\x2\x2B\x1\xFFFF"+
			"\x1\x174\x1\x175\x1\x2B\x4\xFFFF\x1\x2B\x1\xFFFF\x1\x2B\x1\xFFFF\x1\x2B"+
			"\x1\x17A\x1\xFFFF\x1\x17B\x1\x17C\x3\xFFFF\x1\x17D\x3\x2B\x2\xFFFF\x3"+
			"\x2B\x1\x184\x4\xFFFF\x2\x2B\x1\x187\x1\x188\x1\x2B\x1\x18A\x1\xFFFF"+
			"\x1\x18B\x1\x18C\x2\xFFFF\x1\x2B\x3\xFFFF\x1\x2B\x1\x18F\x1\xFFFF";
		private const string DFA32_eofS =
			"\x190\xFFFF";
		private const string DFA32_minS =
			"\x1\x9\x1\x62\x1\x2B\x1\x26\x1\x3D\x1\x6F\x1\x61\x2\xFFFF\x1\x65\x1\x2D"+
			"\x1\x0\x1\x30\x1\x6C\x1\x61\x1\x6F\x1\x3D\x1\x66\x3\xFFFF\x1\x6F\x1\x3D"+
			"\x1\xFFFF\x1\x3C\x2\x3D\x1\x61\x1\x3D\x1\x61\x3\xFFFF\x1\x65\x2\xFFFF"+
			"\x2\x68\x1\x61\x1\x68\x1\x3D\x3\xFFFF\x1\x30\x2\xFFFF\x1\x73\x6\xFFFF"+
			"\x1\x3D\x1\xFFFF\x1\x6F\x1\x65\x1\x74\x1\x73\x2\x61\x1\x6E\x1\x62\x1"+
			"\x24\x3\xFFFF\x1\x0\x5\xFFFF\x1\x73\x1\x75\x1\x70\x1\x6C\x1\x6E\x1\x6F"+
			"\x1\x72\x1\x6E\x1\x74\x1\xFFFF\x1\x3D\x1\xFFFF\x1\x24\x1\x70\x1\x24\x1"+
			"\x6E\x4\xFFFF\x1\x3D\x5\xFFFF\x1\x74\x1\x77\x1\x6C\x1\x3D\x1\xFFFF\x1"+
			"\x63\x1\x69\x1\x62\x1\x74\x1\x6F\x1\x61\x1\x70\x1\x69\x1\x6E\x1\x69\x1"+
			"\x61\x1\x70\x1\x72\x2\x69\x1\x74\x4\xFFFF\x1\x74\x2\xFFFF\x1\x6C\x1\x61"+
			"\x2\x65\x1\x63\x1\x72\x2\x73\x1\x75\x1\x61\x1\x65\x1\x62\x2\xFFFF\x1"+
			"\x65\x1\x6D\x1\x6F\x1\x65\x1\x73\x2\x61\x1\x24\x1\x63\x1\x6F\x1\xFFFF"+
			"\x1\x3D\x2\xFFFF\x1\x6C\x1\x74\x1\x24\x1\xFFFF\x1\x67\x2\xFFFF\x1\x69"+
			"\x1\x24\x1\x6C\x2\xFFFF\x1\x6B\x1\x76\x1\x74\x1\x6C\x1\x75\x1\x72\x1"+
			"\x74\x1\x65\x1\x74\x1\x63\x1\x73\x1\x6F\x1\x6E\x1\x65\x1\x24\x1\x65\x1"+
			"\x24\x1\x64\x1\x61\x1\x6C\x1\x68\x1\x72\x1\x65\x1\x6B\x2\x24\x1\x68\x1"+
			"\x24\x1\x73\x1\x74\x1\x69\x1\x67\x1\x75\x1\x74\x1\x6C\x2\x24\x1\x72\x1"+
			"\x6E\x1\x65\x1\x6C\x1\x74\x1\xFFFF\x1\x74\x1\x24\x2\xFFFF\x1\x65\x1\x72"+
			"\x1\x61\x1\x72\x1\xFFFF\x1\x24\x1\x76\x1\xFFFF\x1\x24\x2\x61\x1\x65\x1"+
			"\x69\x1\x72\x1\x74\x1\x69\x1\x72\x1\x63\x1\x68\x1\x24\x1\x77\x1\x73\x1"+
			"\x24\x1\xFFFF\x1\x6F\x1\xFFFF\x1\x24\x1\x74\x1\x65\x1\x24\x2\x61\x1\x24"+
			"\x2\xFFFF\x1\x24\x1\xFFFF\x2\x24\x1\x6E\x1\x67\x1\x6C\x2\x65\x2\xFFFF"+
			"\x1\x74\x1\x64\x3\x24\x1\x69\x1\xFFFF\x1\x6D\x1\x74\x1\x6E\x1\x66\x1"+
			"\xFFFF\x1\x65\x1\xFFFF\x1\x67\x1\x74\x2\x63\x1\x6E\x1\x24\x1\x63\x1\x24"+
			"\x1\x68\x1\x72\x1\xFFFF\x1\x24\x1\x69\x1\xFFFF\x1\x66\x1\xFFFF\x1\x69"+
			"\x1\x24\x1\xFFFF\x1\x63\x1\x6E\x4\xFFFF\x1\x75\x1\x65\x1\x74\x3\x24\x1"+
			"\x73\x1\xFFFF\x1\x79\x2\xFFFF\x1\x6F\x1\x65\x1\x24\x1\x63\x1\x61\x1\x24"+
			"\x2\x65\x1\x74\x2\x24\x1\xFFFF\x1\x24\x1\xFFFF\x1\x24\x1\x6F\x1\x24\x1"+
			"\xFFFF\x1\x65\x1\x24\x1\x6C\x1\xFFFF\x1\x74\x1\x24\x1\x65\x1\x72\x1\x24"+
			"\x3\xFFFF\x2\x24\x2\x6E\x1\xFFFF\x1\x65\x1\x63\x1\xFFFF\x2\x24\x1\x65"+
			"\x4\xFFFF\x1\x6E\x1\xFFFF\x1\x6E\x1\xFFFF\x1\x65\x1\x24\x1\xFFFF\x2\x24"+
			"\x3\xFFFF\x1\x24\x1\x74\x1\x6F\x1\x65\x2\xFFFF\x1\x64\x1\x69\x1\x74\x1"+
			"\x24\x4\xFFFF\x1\x73\x1\x66\x2\x24\x1\x7A\x1\x24\x1\xFFFF\x2\x24\x2\xFFFF"+
			"\x1\x65\x3\xFFFF\x1\x64\x1\x24\x1\xFFFF";
		private const string DFA32_maxS =
			"\x1\x3000\x1\x62\x3\x3D\x1\x79\x1\x6F\x2\xFFFF\x1\x6F\x1\x3D\x1\xFFFF"+
			"\x1\x39\x1\x78\x1\x75\x1\x6F\x1\x3E\x1\x6E\x3\xFFFF\x1\x6F\x1\x7C\x1"+
			"\xFFFF\x3\x3D\x1\x75\x1\x3D\x1\x75\x3\xFFFF\x1\x65\x2\xFFFF\x2\x79\x1"+
			"\x6F\x1\x69\x1\x3D\x3\xFFFF\x1\x78\x2\xFFFF\x1\x73\x6\xFFFF\x1\x3D\x1"+
			"\xFFFF\x1\x6F\x1\x65\x2\x74\x2\x61\x1\x6E\x1\x6C\x1\x7A\x3\xFFFF\x1\xFFFF"+
			"\x5\xFFFF\x1\x73\x1\x75\x1\x74\x1\x6C\x1\x6E\x1\x6F\x1\x72\x1\x6E\x1"+
			"\x74\x1\xFFFF\x1\x3E\x1\xFFFF\x1\x7A\x1\x70\x1\x7A\x1\x6E\x4\xFFFF\x1"+
			"\x3D\x5\xFFFF\x1\x74\x1\x77\x1\x6C\x1\x3D\x1\xFFFF\x1\x63\x1\x6F\x1\x62"+
			"\x1\x74\x1\x6F\x1\x61\x1\x70\x1\x69\x1\x6E\x1\x72\x1\x79\x1\x70\x1\x72"+
			"\x1\x6C\x1\x69\x1\x74\x4\xFFFF\x1\x74\x2\xFFFF\x1\x6C\x1\x61\x2\x65\x1"+
			"\x63\x1\x72\x1\x73\x1\x74\x1\x75\x1\x61\x1\x65\x1\x62\x2\xFFFF\x1\x65"+
			"\x1\x6D\x1\x6F\x1\x65\x1\x73\x2\x61\x1\x7A\x1\x63\x1\x6F\x1\xFFFF\x1"+
			"\x3D\x2\xFFFF\x1\x6F\x1\x74\x1\x7A\x1\xFFFF\x1\x67\x2\xFFFF\x1\x69\x1"+
			"\x7A\x1\x6C\x2\xFFFF\x1\x6B\x1\x76\x1\x74\x1\x6C\x1\x75\x1\x72\x1\x74"+
			"\x1\x65\x1\x74\x1\x63\x1\x73\x1\x6F\x1\x6E\x1\x65\x1\x7A\x1\x65\x1\x7A"+
			"\x1\x64\x1\x61\x1\x6C\x1\x68\x1\x72\x1\x65\x1\x6B\x2\x7A\x1\x68\x1\x7A"+
			"\x1\x73\x1\x74\x1\x69\x1\x67\x1\x75\x1\x74\x1\x6C\x2\x7A\x1\x72\x1\x6E"+
			"\x1\x65\x1\x6C\x1\x74\x1\xFFFF\x1\x74\x1\x7A\x2\xFFFF\x1\x65\x1\x72\x1"+
			"\x61\x1\x72\x1\xFFFF\x1\x7A\x1\x76\x1\xFFFF\x1\x7A\x2\x61\x1\x65\x1\x69"+
			"\x1\x72\x1\x74\x1\x69\x1\x72\x1\x63\x1\x68\x1\x7A\x1\x77\x1\x73\x1\x7A"+
			"\x1\xFFFF\x1\x6F\x1\xFFFF\x1\x7A\x1\x74\x1\x65\x1\x7A\x2\x61\x1\x7A\x2"+
			"\xFFFF\x1\x7A\x1\xFFFF\x2\x7A\x1\x6E\x1\x67\x1\x6C\x2\x65\x2\xFFFF\x1"+
			"\x74\x1\x64\x3\x7A\x1\x69\x1\xFFFF\x1\x6D\x1\x74\x1\x6E\x1\x66\x1\xFFFF"+
			"\x1\x65\x1\xFFFF\x1\x67\x1\x74\x2\x63\x1\x6E\x1\x7A\x1\x63\x1\x7A\x1"+
			"\x68\x1\x72\x1\xFFFF\x1\x7A\x1\x69\x1\xFFFF\x1\x66\x1\xFFFF\x1\x69\x1"+
			"\x7A\x1\xFFFF\x1\x63\x1\x6E\x4\xFFFF\x1\x75\x1\x65\x1\x74\x3\x7A\x1\x73"+
			"\x1\xFFFF\x1\x79\x2\xFFFF\x1\x6F\x1\x65\x1\x7A\x1\x63\x1\x61\x1\x7A\x2"+
			"\x65\x1\x74\x2\x7A\x1\xFFFF\x1\x7A\x1\xFFFF\x1\x7A\x1\x6F\x1\x7A\x1\xFFFF"+
			"\x1\x65\x1\x7A\x1\x6C\x1\xFFFF\x1\x74\x1\x7A\x1\x65\x1\x72\x1\x7A\x3"+
			"\xFFFF\x2\x7A\x2\x6E\x1\xFFFF\x1\x65\x1\x63\x1\xFFFF\x2\x7A\x1\x65\x4"+
			"\xFFFF\x1\x6E\x1\xFFFF\x1\x6E\x1\xFFFF\x1\x65\x1\x7A\x1\xFFFF\x2\x7A"+
			"\x3\xFFFF\x1\x7A\x1\x74\x1\x6F\x1\x65\x2\xFFFF\x1\x64\x1\x69\x1\x74\x1"+
			"\x7A\x4\xFFFF\x1\x73\x1\x66\x4\x7A\x1\xFFFF\x2\x7A\x2\xFFFF\x1\x65\x3"+
			"\xFFFF\x1\x64\x1\x7A\x1\xFFFF";
		private const string DFA32_acceptS =
			"\x7\xFFFF\x1\xE\x1\xF\x9\xFFFF\x1\x31\x1\x33\x1\x34\x2\xFFFF\x1\x37\x6"+
			"\xFFFF\x1\x4A\x1\x4B\x1\x4C\x1\xFFFF\x1\x4E\x1\x50\x5\xFFFF\x1\x6C\x1"+
			"\x6D\x1\x70\x1\xFFFF\x1\x71\x1\x74\x1\xFFFF\x1\x3\x1\x2D\x1\x2\x1\x5"+
			"\x1\x32\x1\x4\x1\xFFFF\x1\x6\x9\xFFFF\x1\x13\x1\x5A\x1\x59\x1\xFFFF\x1"+
			"\x6E\x1\x6F\x1\x16\x1\x75\x1\x19\x9\xFFFF\x1\x28\x1\xFFFF\x1\x27\x4\xFFFF"+
			"\x1\x36\x1\x45\x1\x44\x1\x39\x1\xFFFF\x1\x38\x1\x3B\x1\x3A\x1\x3D\x1"+
			"\x3C\x4\xFFFF\x1\x41\x10\xFFFF\x1\x6B\x1\x6A\x1\x73\x1\x72\x1\xFFFF\x1"+
			"\x4F\x1\x1D\xC\xFFFF\x1\x18\x1\x17\xA\xFFFF\x1\x55\x1\xFFFF\x1\x54\x1"+
			"\x29\x3\xFFFF\x1\x2C\x1\xFFFF\x1\x52\x1\x51\x3\xFFFF\x1\x42\x1\x3F\x2A"+
			"\xFFFF\x1\x24\x2\xFFFF\x1\x57\x1\x56\x4\xFFFF\x1\x2F\x2\xFFFF\x1\x40"+
			"\xF\xFFFF\x1\x63\x1\xFFFF\x1\x65\x7\xFFFF\x1\x9\x1\xA\x1\xFFFF\x1\xC"+
			"\x7\xFFFF\x1\x1B\x1\x1C\x6\xFFFF\x1\x26\x4\xFFFF\x1\x35\x1\xFFFF\x1\x43"+
			"\xA\xFFFF\x1\x5E\x2\xFFFF\x1\x62\x1\xFFFF\x1\x66\x2\xFFFF\x1\x69\x2\xFFFF"+
			"\x1\x8\x1\xB\x1\xD\x1\x10\x7\xFFFF\x1\x20\x1\xFFFF\x1\x21\x1\x23\xB\xFFFF"+
			"\x1\x53\x1\xFFFF\x1\x5B\x3\xFFFF\x1\x5F\x3\xFFFF\x1\x68\x5\xFFFF\x1\x15"+
			"\x1\x1A\x1\x1E\x4\xFFFF\x1\x2B\x2\xFFFF\x1\x3E\x3\xFFFF\x1\x49\x1\x4D"+
			"\x1\x58\x1\x5C\x1\xFFFF\x1\x60\x1\xFFFF\x1\x64\x2\xFFFF\x1\x7\x2\xFFFF"+
			"\x1\x14\x1\x1F\x1\x22\x4\xFFFF\x1\x46\x1\x47\x4\xFFFF\x1\x1\x1\x11\x1"+
			"\x12\x1\x25\x6\xFFFF\x1\x67\x2\xFFFF\x1\x30\x1\x48\x1\xFFFF\x1\x61\x1"+
			"\x2A\x1\x2E\x2\xFFFF\x1\x5D";
		private const string DFA32_specialS =
			"\xB\xFFFF\x1\x0\x38\xFFFF\x1\x1\x14B\xFFFF}>";
		private static readonly string[] DFA32_transitionS =
			{
				"\x1\x29\x1\x2A\x2\x29\x1\x2A\x12\xFFFF\x1\x29\x1\x1C\x1\x2E\x2\xFFFF"+
				"\x1\x19\x1\x3\x1\x2E\x1\x17\x1\x22\x1\x1A\x1\x2\x1\x8\x1\xA\x1\xC\x1"+
				"\xB\x1\x2C\x9\x2D\x1\x7\x1\x23\x1\x18\x1\x4\x1\x10\x1\x1E\x1B\xFFFF"+
				"\x1\x14\x1\xFFFF\x1\x20\x1\x28\x2\xFFFF\x1\x1\x1\x5\x1\x6\x1\x9\x1\xD"+
				"\x1\xE\x1\xF\x1\xFFFF\x1\x11\x2\xFFFF\x1\x15\x1\xFFFF\x1\x1B\x1\xFFFF"+
				"\x1\x1D\x1\xFFFF\x1\x21\x1\x24\x1\x25\x1\xFFFF\x1\x26\x1\x27\x3\xFFFF"+
				"\x1\x13\x1\x16\x1\x1F\x1\x12\x21\xFFFF\x1\x29\x15DF\xFFFF\x1\x29\x18D"+
				"\xFFFF\x1\x29\x7F1\xFFFF\xB\x29\x1D\xFFFF\x2\x2A\x5\xFFFF\x1\x29\x2F"+
				"\xFFFF\x1\x29\xFA0\xFFFF\x1\x29",
				"\x1\x2F",
				"\x1\x31\x11\xFFFF\x1\x30",
				"\x1\x34\x16\xFFFF\x1\x33",
				"\x1\x36",
				"\x1\x38\x2\xFFFF\x1\x39\x6\xFFFF\x1\x3A",
				"\x1\x3B\x6\xFFFF\x1\x3C\x3\xFFFF\x1\x3D\x2\xFFFF\x1\x3E",
				"",
				"",
				"\x1\x3F\x9\xFFFF\x1\x40",
				"\x1\x41\xF\xFFFF\x1\x42",
				"\xA\x48\x1\xFFFF\x2\x48\x1\xFFFF\x1C\x48\x1\x45\x4\x48\x1\x46\xD\x48"+
				"\x1\x44\x1FEA\x48\x2\xFFFF\xDFD6\x48",
				"\xA\x2D",
				"\x1\x4A\x1\xFFFF\x1\x4B\x9\xFFFF\x1\x4C",
				"\x1\x4D\x7\xFFFF\x1\x4E\x2\xFFFF\x1\x4F\x2\xFFFF\x1\x50\x5\xFFFF\x1"+
				"\x51",
				"\x1\x52",
				"\x1\x53\x1\x54",
				"\x1\x56\x6\xFFFF\x1\x57\x1\x58",
				"",
				"",
				"",
				"\x1\x59",
				"\x1\x5B\x3E\xFFFF\x1\x5A",
				"",
				"\x1\x5E\x1\x5D",
				"\x1\x60",
				"\x1\x62",
				"\x1\x64\x3\xFFFF\x1\x65\xF\xFFFF\x1\x66",
				"\x1\x67",
				"\x1\x69\x10\xFFFF\x1\x6A\x2\xFFFF\x1\x6B",
				"",
				"",
				"",
				"\x1\x6C",
				"",
				"",
				"\x1\x6D\xB\xFFFF\x1\x6E\x1\x6F\x1\xFFFF\x1\x70\x1\xFFFF\x1\x71",
				"\x1\x72\x9\xFFFF\x1\x73\x6\xFFFF\x1\x74",
				"\x1\x75\xD\xFFFF\x1\x76",
				"\x1\x77\x1\x78",
				"\x1\x79",
				"",
				"",
				"",
				"\x8\x7C\x20\xFFFF\x1\x7B\x1F\xFFFF\x1\x7B",
				"",
				"",
				"\x1\x7D",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x7E",
				"",
				"\x1\x80",
				"\x1\x81",
				"\x1\x82",
				"\x1\x83\x1\x84",
				"\x1\x85",
				"\x1\x86",
				"\x1\x87",
				"\x1\x88\x3\xFFFF\x1\x89\x5\xFFFF\x1\x8A",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x14\x2B\x1\x8B\x5\x2B",
				"",
				"",
				"",
				"\xA\x48\x1\xFFFF\x2\x48\x1\xFFFF\x201A\x48\x2\xFFFF\xDFD6\x48",
				"",
				"",
				"",
				"",
				"",
				"\x1\x8E",
				"\x1\x8F",
				"\x1\x90\x3\xFFFF\x1\x91",
				"\x1\x92",
				"\x1\x93",
				"\x1\x94",
				"\x1\x95",
				"\x1\x96",
				"\x1\x97",
				"",
				"\x1\x98\x1\x99",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x9C",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x12\x2B\x1\x9D\x1\x9E\x6\x2B",
				"\x1\xA0",
				"",
				"",
				"",
				"",
				"\x1\xA1",
				"",
				"",
				"",
				"",
				"",
				"\x1\xA3",
				"\x1\xA4",
				"\x1\xA5",
				"\x1\xA6",
				"",
				"\x1\xA8",
				"\x1\xA9\x5\xFFFF\x1\xAA",
				"\x1\xAB",
				"\x1\xAC",
				"\x1\xAD",
				"\x1\xAE",
				"\x1\xAF",
				"\x1\xB0",
				"\x1\xB1",
				"\x1\xB2\x8\xFFFF\x1\xB3",
				"\x1\xB4\x13\xFFFF\x1\xB5\x3\xFFFF\x1\xB6",
				"\x1\xB7",
				"\x1\xB8",
				"\x1\xB9\x2\xFFFF\x1\xBA",
				"\x1\xBB",
				"\x1\xBC",
				"",
				"",
				"",
				"",
				"\x1\xBD",
				"",
				"",
				"\x1\xBE",
				"\x1\xBF",
				"\x1\xC0",
				"\x1\xC1",
				"\x1\xC2",
				"\x1\xC3",
				"\x1\xC4",
				"\x1\xC5\x1\xC6",
				"\x1\xC7",
				"\x1\xC8",
				"\x1\xC9",
				"\x1\xCA",
				"",
				"",
				"\x1\xCB",
				"\x1\xCC",
				"\x1\xCD",
				"\x1\xCE",
				"\x1\xCF",
				"\x1\xD0",
				"\x1\xD1",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xD3",
				"\x1\xD4",
				"",
				"\x1\xD5",
				"",
				"",
				"\x1\xD7\x2\xFFFF\x1\xD8",
				"\x1\xD9",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x4\x2B\x1\xDA\x15\x2B",
				"",
				"\x1\xDC",
				"",
				"",
				"\x1\xDD",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xDF",
				"",
				"",
				"\x1\xE0",
				"\x1\xE1",
				"\x1\xE2",
				"\x1\xE3",
				"\x1\xE4",
				"\x1\xE5",
				"\x1\xE6",
				"\x1\xE7",
				"\x1\xE8",
				"\x1\xE9",
				"\x1\xEA",
				"\x1\xEB",
				"\x1\xEC",
				"\x1\xED",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xEF",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xF1",
				"\x1\xF2",
				"\x1\xF3",
				"\x1\xF4",
				"\x1\xF5",
				"\x1\xF6",
				"\x1\xF7",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xFA",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\xFC",
				"\x1\xFD",
				"\x1\xFE",
				"\x1\xFF",
				"\x1\x100",
				"\x1\x101",
				"\x1\x102",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x105",
				"\x1\x106",
				"\x1\x107",
				"\x1\x108",
				"\x1\x109",
				"",
				"\x1\x10A",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"\x1\x10C",
				"\x1\x10D",
				"\x1\x10E",
				"\x1\x10F",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x111",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x113",
				"\x1\x114",
				"\x1\x115",
				"\x1\x116",
				"\x1\x117",
				"\x1\x118",
				"\x1\x119",
				"\x1\x11A",
				"\x1\x11B",
				"\x1\x11C",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x11E",
				"\x1\x11F",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x121",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x123",
				"\x1\x124",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x126",
				"\x1\x127",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x12C",
				"\x1\x12D",
				"\x1\x12E",
				"\x1\x12F",
				"\x1\x130",
				"",
				"",
				"\x1\x131",
				"\x1\x132",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\xB\x2B\x1\x134\xE\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x137",
				"",
				"\x1\x138",
				"\x1\x139",
				"\x1\x13A",
				"\x1\x13B",
				"",
				"\x1\x13C",
				"",
				"\x1\x13D",
				"\x1\x13E",
				"\x1\x13F",
				"\x1\x140",
				"\x1\x141",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x143",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x145",
				"\x1\x146",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x12\x2B\x1\x147\x7\x2B",
				"\x1\x149",
				"",
				"\x1\x14A",
				"",
				"\x1\x14B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x14D",
				"\x1\x14E",
				"",
				"",
				"",
				"",
				"\x1\x14F",
				"\x1\x150",
				"\x1\x151",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x155",
				"",
				"\x1\x156",
				"",
				"",
				"\x1\x157",
				"\x1\x158",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x15A",
				"\x1\x15B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x15D",
				"\x1\x15E",
				"\x1\x15F",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x164",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x166",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x168",
				"",
				"\x1\x169",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x16B",
				"\x1\x16C",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x170",
				"\x1\x171",
				"",
				"\x1\x172",
				"\x1\x173",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x176",
				"",
				"",
				"",
				"",
				"\x1\x177",
				"",
				"\x1\x178",
				"",
				"\x1\x179",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x17E",
				"\x1\x17F",
				"\x1\x180",
				"",
				"",
				"\x1\x181",
				"\x1\x182",
				"\x1\x183",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"",
				"",
				"\x1\x185",
				"\x1\x186",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x189",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				"",
				"",
				"\x1\x18D",
				"",
				"",
				"",
				"\x1\x18E",
				"\x1\x2B\xB\xFFFF\xA\x2B\x7\xFFFF\x1A\x2B\x1\xFFFF\x1\x2B\x2\xFFFF\x1"+
				"\x2B\x1\xFFFF\x1A\x2B",
				""
			};

		private static readonly short[] DFA32_eot = DFA.UnpackEncodedString(DFA32_eotS);
		private static readonly short[] DFA32_eof = DFA.UnpackEncodedString(DFA32_eofS);
		private static readonly char[] DFA32_min = DFA.UnpackEncodedStringToUnsignedChars(DFA32_minS);
		private static readonly char[] DFA32_max = DFA.UnpackEncodedStringToUnsignedChars(DFA32_maxS);
		private static readonly short[] DFA32_accept = DFA.UnpackEncodedString(DFA32_acceptS);
		private static readonly short[] DFA32_special = DFA.UnpackEncodedString(DFA32_specialS);
		private static readonly short[][] DFA32_transition;

		static DFA32()
		{
			int numStates = DFA32_transitionS.Length;
			DFA32_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA32_transition[i] = DFA.UnpackEncodedString(DFA32_transitionS[i]);
			}
		}

		public DFA32( BaseRecognizer recognizer, SpecialStateTransitionHandler specialStateTransition )
			: base(specialStateTransition)
		{
			this.recognizer = recognizer;
			this.decisionNumber = 32;
			this.eot = DFA32_eot;
			this.eof = DFA32_eof;
			this.min = DFA32_min;
			this.max = DFA32_max;
			this.accept = DFA32_accept;
			this.special = DFA32_special;
			this.transition = DFA32_transition;
		}

		public override string Description { get { return "1:1: Tokens : ( ABSTRACT | ADD | ADDASS | AND | ANDASS | ASSIGN | BOOLEAN | BREAK | BYTE | CASE | CATCH | CHAR | CLASS | COLON | COMMA | CONST | CONTINUE | DEBUGGER | DEC | DEFAULT | DELETE | DIV | DIVASS | DO | DOT | DOUBLE | ELSE | ENUM | EQ | EXPORT | EXTENDS | FALSE | FINAL | FINALLY | FLOAT | FOR | FUNCTION | GOTO | GT | GTE | IF | IMPLEMENTS | IMPORT | IN | INC | INSTANCEOF | INT | INTERFACE | INV | LAND | LBRACE | LBRACK | LONG | LOR | LPAREN | LT | LTE | MOD | MODASS | MUL | MULASS | NATIVE | NEQ | NEW | NOT | NSAME | NULL | OR | ORASS | PACKAGE | PRIVATE | PROTECTED | PUBLIC | QUE | RBRACE | RBRACK | RETURN | RPAREN | SAME | SEMIC | SHL | SHLASS | SHORT | SHR | SHRASS | SHU | SHUASS | STATIC | SUB | SUBASS | SUPER | SWITCH | SYNCHRONIZED | THIS | THROW | THROWS | TRANSIENT | TRUE | TRY | TYPEOF | VAR | VOID | VOLATILE | WHILE | WITH | XOR | XORASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral );"; } }

		public override void Error(NoViableAltException nvae)
		{
			DebugRecognitionException(nvae);
		}
	}

	private int SpecialStateTransition32(DFA dfa, int s, IIntStream _input)
	{
		IIntStream input = _input;
		int _s = s;
		switch (s)
		{
			case 0:
				int LA32_11 = input.LA(1);


				int index32_11 = input.Index;
				input.Rewind();
				s = -1;
				if ( (LA32_11=='=') ) {s = 68;}

				else if ( (LA32_11=='*') ) {s = 69;}

				else if ( (LA32_11=='/') ) {s = 70;}

				else if ( ((LA32_11>='\u0000' && LA32_11<='\t')||(LA32_11>='\u000B' && LA32_11<='\f')||(LA32_11>='\u000E' && LA32_11<=')')||(LA32_11>='+' && LA32_11<='.')||(LA32_11>='0' && LA32_11<='<')||(LA32_11>='>' && LA32_11<='\u2027')||(LA32_11>='\u202A' && LA32_11<='\uFFFF')) && (( AreRegularExpressionsEnabled() ))) {s = 72;}

				else s = 71;


				input.Seek(index32_11);
				if ( s>=0 ) return s;
				break;
			case 1:
				int LA32_68 = input.LA(1);


				int index32_68 = input.Index;
				input.Rewind();
				s = -1;
				if ( ((LA32_68>='\u0000' && LA32_68<='\t')||(LA32_68>='\u000B' && LA32_68<='\f')||(LA32_68>='\u000E' && LA32_68<='\u2027')||(LA32_68>='\u202A' && LA32_68<='\uFFFF')) && (( AreRegularExpressionsEnabled() ))) {s = 72;}

				else s = 141;


				input.Seek(index32_68);
				if ( s>=0 ) return s;
				break;
		}
		NoViableAltException nvae = new NoViableAltException(dfa.Description, 32, _s, input);
		dfa.Error(nvae);
		throw nvae;
	}
 
	#endregion

}
