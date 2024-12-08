using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;
namespace Player_basic_attribute
{
    public class Tutorial : MonoBehaviour
    {

        public float speed = 5.6f;
        public Rigidbody2D rb;
        public float xVelocity;//这个变量主要来存储GetAxis或GetAxisRaw获取的值
        public float jumpForce;

        public float fallMultiplier;//空中降落的速度
        public float lowJumpMultiplier;//跳跃高度的限制级别（数值越大跳的越矮）
        public bool pressJump;
        public GameObject player;
        public int jumpNum;//一共能跳几次
        public int jumpRemainNum;//还能跳几次
        public bool isOnGround;//是否在地面上

        public bool pressHit;

        public float groundDistance = 0.2f;//射线的长度
        public float footOffset = 0.4f;//两条射线的距离
        public float rayPositionY = -0.5f;//射线的Y轴
        public LayerMask groundLayer;
        // Start is called before the first frame update
        public bool colider = false;
        public GameObject at;
        public Animator skil;
        public  float hit_mid = 0.3f, skill1_cd, skill2_cd, skill3_cd;

        public float skill_internal;//技能播放最小时间
        private static float hit_up, skill1_up, skill2_up, skill3_up;//保证普工cd&&技能cd的累加计时
        public static float Skill1_up {  get=>skill1_up; }
        public static float Skill2_up { get => skill2_up; }
        public static float Skill3_up { get => skill3_up; }
        private bool fire = false, fire1 = false, fire2 = false, fire3 = false;

        public static float hit_power; //攻击力与技能伤害
        public float hit_basic;
        public float skill1_damage, skill2_damage, skill3_damage;

        public static float magic_consume1=5, magic_consume2=10, magic_consume3 = 10;

        public Slider Hp, Mp, Grade; //血条 蓝条 经验条
        public Text text1, text2;
        public float hp_max,mp_max;
        public static float hp, mp;
        void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
            skil = GetComponent<Animator>();
            hit_up = hit_mid;
            Hp.maxValue = hp_max;Mp.maxValue = mp_max;
            hp = hp_max;mp = mp_max;
        }

        // Update is called once per frame
        void Update()
        {
            Blood_update();
            pressJump = Input.GetButton("Jump");
            Jump();
            pressHit = Input.GetButton("Hitone");
            Hit();
        }
        void FixedUpdate()
        {

            PhysicsCheck();
            GroundMovement();

        }
        public void GroundMovement()
        {
            xVelocity = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(xVelocity * speed, rb.velocity.y);
            if (xVelocity < 0)
            {   //transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
                player.GetComponent<SpriteRenderer>().flipX = true;
                at.GetComponent<Collider2D>().offset = new Vector2((float)-0.613914, (float)0.02790475);
            }
            if (xVelocity > 0)
            {      //transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y ,0);
                player.GetComponent<SpriteRenderer>().flipX = false;
                at.GetComponent<Collider2D>().offset = new Vector2((float)0.613914, (float)0.02790475);
            }
        }
        void PhysicsCheck()
        {
            RaycastHit2D leftCheck = Raycast(new Vector2(-footOffset, rayPositionY), Vector2.down, groundDistance, groundLayer);
            RaycastHit2D RightCheck = Raycast(new Vector2(footOffset, rayPositionY), Vector2.down, groundDistance, groundLayer);
            if (leftCheck || RightCheck)
            {
                isOnGround = true;

            }

            else
            {
                isOnGround = false;

            }
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (isOnGround)
                {

                    jumpRemainNum = jumpNum;
                }
                if (jumpRemainNum-- > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);

                }
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;

            }
            else if (rb.velocity.y > 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;

            }
        }
        void Hit()
        {

            if (Input.GetKeyDown(KeyCode.J))
            {
                if (fire)
                {
                    fire = false;
                    skil.SetTrigger("j");
                    Debug.Log("攻击");
                    hp -= 30;
                    hit_power = hit_basic;
                    //给运动打破睡眠
                    transform.localPosition = new Vector3(transform.localPosition.x + 0.0001f, transform.localPosition.y, 0);
                }
            }
            else if (!fire)
            {
                hit_up += Time.deltaTime;
                if (hit_up > hit_mid)
                {
                    fire = true;
                    hit_up = 0;
                }
            }
            if (Input.GetKeyDown(KeyCode.U))
            {
                if (fire1)
                {
                    fire1 = false;
                    skill1_up = 0;
                    skil.SetTrigger("1");
                    Debug.Log("技能1");

                    mp -= magic_consume1;

                    hit_power = skill1_damage;
                    //让技能间有释放间隔
                    fire2 = false;
                    fire3 = false;
                    fire = false;
                    hit_up = hit_mid-skill_internal;
                    skill2_up = skill2_cd - skill_internal;
                    skill3_up = skill3_cd - skill_internal;
                    //给运动打破睡眠
                    transform.localPosition = new Vector3(transform.localPosition.x + 0.0001f, transform.localPosition.y, 0);
                }
            }
            else if (!fire1)
            {
                skill1_up += Time.deltaTime;
                if (skill1_up > skill1_cd)
                {
                    fire1 = true;
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (fire2)
                {
                    fire2 = false;
                    skill2_up = 0;
                    skil.SetTrigger("2");
                    Debug.Log("技能2");
                    mp -= magic_consume2;

                    hit_power = skill2_damage;

                    fire = false;
                    hit_up = hit_mid - skill_internal;
                    fire1 = false;
                    fire3 = false;
                    skill1_up = skill1_cd - skill_internal;
                    skill3_up = skill3_cd - skill_internal;
                    //给运动打破睡眠
                    transform.localPosition = new Vector3(transform.localPosition.x + 0.0001f, transform.localPosition.y, 0);
                }
            }
            else if (!fire2)
            {
                skill2_up += Time.deltaTime;
                if (skill2_up > skill2_cd)
                {
                    fire2 = true;
                    
                }
            }
            if (Input.GetKeyDown(KeyCode.O))
            {
                if (fire3)
                {
                    fire3 = false;
                    skill3_up = 0;
                    skil.SetTrigger("3");
                    Debug.Log("技能3");

                    mp -= magic_consume3;

                    hit_power = skill3_damage;
                    fire = false;
                    hit_up = hit_mid - skill_internal;
                    fire2 = false;
                    fire1 = false;
                    skill2_up = skill2_cd - skill_internal;
                    skill1_up = skill1_cd - skill_internal;
                    //给运动打破睡眠
                    transform.localPosition = new Vector3(transform.localPosition.x + 0.0001f, transform.localPosition.y, 0);
                }
            }
            else if (!fire3)
            {
                skill3_up += Time.deltaTime;
                if (skill3_up > skill3_cd)
                {
                    fire3 = true;
                }
            }
        }
        RaycastHit2D Raycast(Vector2 offset, Vector2 rayDirection, float length, LayerMask layer)
        {

            Vector2 pos = transform.position;
            RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDirection, length, layer);

            Color color = hit ? Color.red : Color.green;

            Debug.DrawRay(pos + offset, rayDirection * length, color);
            return hit;
        }
        // 碰撞开始
        void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("检测到物体" + other.gameObject.name);
            colider = true;
            //给一个力 有方向*大小 模式 
            if (player.GetComponent<SpriteRenderer>().flipX == true)
                other.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
            else other.GetComponent<Rigidbody2D>().AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }
        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("离开物体" + other.gameObject.name);
        }
        private void Blood_update()
        {
            Hp.value = hp;
            Mp.value = mp;
            text1.text = hp.ToString() + " /  " + hp_max.ToString();
            text2.text = mp.ToString() + " /  " + mp_max.ToString();
        } 
    }
}
