using UnityEngine;
using UnityEngine.UI;

public class BuffManager : MonoBehaviour
{
    public static BuffManager Instance;

    [Header("バフ一覧")]
    [SerializeField] private BuffData[] buffs;

    [Header("バフ選択UI")]
    [SerializeField] private GameObject buffPanel;
    [SerializeField] private Image[] buffImages;
    [SerializeField] private Button[] buffButtons;

    private BuffData[] currentBuffs;

    void Awake()
    {
        Instance = this;
    }

    public void OpenBuffUI()
    {
        Time.timeScale = 0;

        currentBuffs = GetRandomBuffs(3);

        for (int i = 0; i < 3; i++)
        {
            buffImages[i].sprite = currentBuffs[i].icon;

            int index = i;
            buffButtons[i].onClick.RemoveAllListeners();
            buffButtons[i].onClick.AddListener(() => SelectBuff(index));
        }

        buffPanel.SetActive(true);
    }

    private BuffData[] GetRandomBuffs(int count)
    {
        BuffData[] result = new BuffData[count];

        for (int i = 0; i < count; i++)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, buffs.Length);
            }
            while (IsAlreadySelected(result, buffs[randomIndex], i));

            result[i] = buffs[randomIndex];
        }

        return result;
    }

    private bool IsAlreadySelected(BuffData[] selected, BuffData target, int count)
    {
        for (int i = 0; i < count; i++)
        {
            if (selected[i] == target)
            {
                return true;
            }
        }

        return false;
    }

    private void SelectBuff(int index)
    {
        BuffData selectedBuff = currentBuffs[index];

        Debug.Log("選択したバフ：" + selectedBuff.buffName);

        ApplyBuff(selectedBuff);

        buffPanel.SetActive(false);
        Time.timeScale = 1;
    }

    private void ApplyBuff(BuffData buff)
    {
        Debug.Log(
            "バフ適用：" +
            buff.buffName +
            " / " +
            buff.buffType +
            " / " +
            buff.value
        );
        switch (buff.buffType)
        {
            case BuffType.AddJump:
                PlayerStats.Instance.maxJump += (int)buff.value;
                break;

            case BuffType.Attackup:
                PlayerStats.Instance.attackPower +=  (int)buff.value;
                break;

            case BuffType.Barrier:
                PlayerStats.Instance.barrier = true;
                break;

            case BuffType.MoveSpeed:
                PlayerStats.Instance.moveSpeed += buff.value;
                break;

            case BuffType.MaxHP:
                PlayerStats.Instance.maxHP += (int)buff.value;
                break;

            case BuffType.AttackRange1:
                // 後で実装
                break;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            OpenBuffUI();
        }
    }
}