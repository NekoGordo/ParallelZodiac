using UnityEngine;

public class NPC : NPCStats {

    //public float MaxDist = 10f;
    int challenegerate ;
    public string npcname = "";

    Aquarius aqua;
    Aries arie;
    Cancer can;
    Capricorn cap;
    Gemini gem;
    Leo leo;
    Libra lib;
    Pisces pisc;
    Sagittarius sagi;
    Scorpio scrop;
    Serpentarius serp;
    Taurus taur;
    Virgo virg;

    public int HealthPoints;//health points
    public int AP;//abillity points(magic damage)
    public int AD;//attack damage
    public int Deffence;
    public int MD;//magic deffence
    public int AS;//attack speed
    public int MaxHp;
    public int CurrentHp;
    public int MaxAp;
    public float CurrentAp = 0;
    public float ATBar;
    public bool hasAttacked;
    //  public Attack attackChosen;
    int rng;

    void RNG () {
        rng = Random.Range ( 1, 14 );
    }

    public void NPCstat () {
        rand = Random.Range ( 1, 33 );
    }

    public NPC () {
        aqua = new Aquarius ();
        arie = new Aries ();
        can = new Cancer ();
        cap = new Capricorn ();
        gem = new Gemini ();
        leo = new Leo ();
        lib = new Libra ();
        pisc = new Pisces ();
        sagi = new Sagittarius ();
        scrop = new Scorpio ();
        serp = new Serpentarius ();
        taur = new Taurus ();
        virg = new Virgo ();

        RNG ();

        if ( rng == 1 ) {
            Name = "";
            Force =rand + aqua.Force;
            Vitality = rand + aqua.Vitality;
            Agility = rand + aqua.Agility ;
            Fortitude = rand + aqua.Fortitude;
            Intellect = rand + aqua.Intellect;
            Rationale = rand + aqua.Rational;
            Charisma = rand + aqua.Charisma;
        }
        if ( rng == 2 ) {
            Name = "";
            Force = rand + arie.Force ;
            Vitality = rand + arie.Vitality;
            Agility = rand + arie.Agility;
            Fortitude = rand + arie.Fortitude;
            Intellect = rand + arie.Intellect;
            Rationale = rand + arie.Rational ;
            Charisma = rand + arie.Charisma ;
        }
        if ( rng == 3 ) {
            Name = "";
            Force = rand + can.Force;
            Vitality = rand + can.Vitality;
            Agility = rand + can.Agility;
            Fortitude = rand + can.Fortitude;
            Intellect = rand + can.Intellect;
            Rationale = rand + can.Rational ;
            Charisma = rand + can.Charisma ;
        }
        if ( rng == 4 ) {
            Name = "";
            Force = rand + cap.Force;
            Vitality = rand + cap.Vitality;
            Agility = rand + cap.Agility ;
            Fortitude = rand + cap.Fortitude;
            Intellect = rand + cap.Intellect ;
            Rationale = rand + cap.Rational;
            Charisma = rand + cap.Charisma;
        }
        if ( rng == 5 ) {
            Name = "";
            Force = rand + gem.Force;
            Vitality = rand + gem.Vitality;
            Agility = rand + gem.Agility;
            Fortitude = rand + gem.Fortitude;
            Intellect = rand + gem.Intellect;
            Rationale = rand + gem.Rational ;
            Charisma = rand + gem.Charisma ;
        }
        if ( rng == 6 ) {
            Name = "";
            Force = rand + leo.Force;
            Vitality = rand + leo.Vitality;
            Agility = rand + leo.Agility;
            Fortitude = rand + leo.Fortitude;
            Intellect = rand + leo.Intellect;
            Rationale = rand + leo.Rational ;
            Charisma = rand + leo.Charisma ;
        }
        if ( rng == 7 ) {
            Name = "";
            Force = rand + lib.Force;
            Vitality = rand + lib.Vitality;
            Agility = rand + lib.Agility;
            Fortitude = rand + lib.Fortitude ;
            Intellect = rand + lib.Intellect;
            Rationale = rand + lib.Rational;
            Charisma = rand + lib.Charisma;
        }
        if ( rng == 8 ) {
            Name = "";
            Force = rand + pisc.Force ;
            Vitality = rand + pisc.Vitality;
            Agility = rand + pisc.Agility ;
            Fortitude = rand + pisc.Fortitude;
            Intellect = rand + pisc.Intellect ;
            Rationale = rand + pisc.Rational ;
            Charisma = rand + pisc.Charisma ;
        }
        if ( rng == 9 ) {
            Name = "";
            Force = rand + sagi.Force ;
            Vitality = rand + sagi.Vitality ;
            Agility = rand + sagi.Agility ;
            Fortitude = rand + sagi.Fortitude ;
            Intellect = rand + sagi.Intellect ;
            Rationale = rand + sagi.Rational ;
            Charisma = rand + sagi.Charisma ;
        }
        if ( rng == 10 ) {
            Name = "";
            Force = rand + scrop.Force ;
            Vitality = rand + scrop.Vitality ;
            Agility = rand + scrop.Agility ;
            Fortitude = rand + scrop.Fortitude ;
            Intellect = rand + scrop.Intellect ;
            Rationale = rand + scrop.Rational ;
            Charisma = rand + scrop.Charisma ;
        }
        if ( rng == 11 ) {
            Name = "";
            Force = rand + serp.Force;
            Vitality = rand + serp.Vitality ;
            Agility = rand + serp.Agility ;
            Fortitude = rand + serp.Fortitude ;
            Intellect = rand + serp.Intellect ;
            Rationale = rand + serp.Rational ;
            Charisma = rand + serp.Charisma ;
        }
        if ( rng == 12 ) {
            Name = "";
            Force = rand + taur.Force;
            Vitality = rand + taur.Vitality;
            Agility = rand + taur.Agility ;
            Fortitude = rand + taur.Fortitude ;
            Intellect = rand + taur.Intellect ;
            Rationale = rand + taur.Rational;
            Charisma = rand + taur.Charisma;
        }
        if ( rng == 13 ) {
            Name = "";
            Force = rand + virg.Force;
            Vitality = rand + virg.Vitality;
            Agility = rand + virg.Agility;
            Fortitude = rand + virg.Fortitude;
            Intellect = rand + virg.Intellect ;
            Rationale = rand + virg.Rationale;
            Charisma = rand + virg.Charisma;
        }
        NPCstat ();
        HealthPoints = (Vitality + Fortitude) / 2;
        AP = (Force + Intellect) / 2;
        Deffence = Vitality;
        AD = Force;
        AS = Agility;
        MD = Rationale;

        ATBar = 0 / 100;

        //HPthing
        MaxHp = HealthPoints;
        CurrentHp = MaxHp;
        //clamps it
        CurrentHp = Mathf.Clamp(CurrentHp, 0, MaxHp);


        // AP bar increasre by timesing agility by time.deltatime
        // divide delta time * agility by 32 
    }

    public void LateUpdate () {
        CurrentAp += ( Time.deltaTime * AS ) / 64;
        if ( CurrentAp >= 1 ) {
            // hasAttacked=attackChosen !=null ? true : false;
            // attackChosen = null;
            CurrentAp = hasAttacked ? 0 : 1;
        }
    }

    public void FixedUpdate () {
       // RaycastHit hit;
        //if ( Physics.Raycast ( transform.position, transform.forward, out hit, MaxDist ) && hit.collider.gameObject.tag == ( "NPC" ) ) {
            if ( Input.GetKeyDown ( KeyCode.H ) ) {
                Fight ();//threatens
            }else if ( Input.GetKeyDown ( KeyCode.G ) ) {
                Challenge ();//chance of attack
            }
        }

    public void Fight () {
        Debug.Log ( "Fight" );
        
    }
    public void Challenge () {
        challenegerate = Random.Range ( 1, 3 );
        if( challenegerate == 1 ) {
            Debug.Log ( "Fight me" );
        }else if ( challenegerate == 2 ) {
            Debug.Log ( "im to good for you" );
        }
    }
}
