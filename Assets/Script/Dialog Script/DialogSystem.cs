using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] private Speaker[] speakers;    // ��ȭ�� �����ϴ� ĳ���͵��� UI �迭
    [SerializeField] private DialogData[] dialogs;  // ���� �б��� ��� ��� �迭
    [SerializeField]
    private bool isAutoStart = true;                // �ڵ� ���� ����
    private bool isFirst = true;                    // ���� 1ȸ�� ȣ���ϱ� ���� ����
    private int currentDialogIndex = -1;            // ���� ��� ����
    private int currentSpeakerIndex = 0;            // ���� ���� �ϴ� ȭ��(Speaker)�� speakers �迭 ����
    private float typingSpeed = 0.1f;               // �ؽ�Ʈ Ÿ���� ȿ���� ����ӵ�
    private bool isTypingEffect = false;            // �ؽ�Ʈ Ÿ���� ȿ���� ���������


    void Awake()
    {
        Setup();
    }

    private void Setup()
    {
        // ��� ��ȭ ���� ���ӿ�����Ʈ ��Ȱ��ȭ
        for (int i = 0; i < speakers.Length; i++)
        {
            SetActiveObjects(speakers[i], false);
            //ĳ���� �̹����� ���̵��� ����
            speakers[i].spriteRenderer.gameObject.SetActive(true);
        }
    }

    public bool UpdateDialog()
    {
        // ��� �бⰡ ���۵� �� 1ȸ�� ȣ��
        if (isFirst == true)
        {

            Setup();

            // �ڵ� ���(isAutoStart=true)���� �����Ǿ� ������ ù ��° ��� ���
            if (isAutoStart) 
                SetNextDialog();

            isFirst = false;
            
        }

        if (Input.GetMouseButtonDown(0))
        {

            if (isTypingEffect == true)
            {
                isTypingEffect = false;

                // Ÿ���� ȿ���� �����ϰ�, ���� ��� ��ü�� ����Ѵ�.
                StopCoroutine("OnTypingText");
                speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
                // ��簡 �Ϸ� �Ǿ��� �� ��µǴ� Ŀ�� Ȱ��ȭ
                speakers[currentSpeakerIndex].objectArrow.SetActive(true);

                return false;
            }

            //��簡 �������� ��� ���� ��� ����
            if (dialogs.Length > currentDialogIndex + 1)
            {
                SetNextDialog();
            }

            // ��簡 �� �̻� ���� ��� ��� ������Ʈ�� ��Ȱ��ȭ�ϰ� true ��ȯ
            else 
            {
                // ���� ��ȭ�� �����ߴ� ��� ĳ����, ��ȭ ���� UI�� ������ �ʰ� ��Ȱ��ȭ
                for (int i = 0; i < speakers.Length; i++)
                {
                    SetActiveObjects(speakers[i], false);
                    // SetActiveObject()�� ĳ���� �̹����� ������ �ʰ� �ϴ� �κ��� ���� ������ ������ ȣ��
                    speakers[i].spriteRenderer.gameObject.SetActive(false);
                    isFirst = true;
                    currentDialogIndex = -1;
                }

                return true;
            }
        }
        
        return false;
    }

    private void SetNextDialog()
    {
        // ���� ȭ���� ���� ���� ������Ʈ ��Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], false);

        // ���� ��縦 �����ϵ���
        currentDialogIndex++;

        // ���� ȭ�� ���� ����
        currentSpeakerIndex = dialogs[currentDialogIndex].speakerIndex;

        // ���� ȭ���� ��ȭ ���� ������Ʈ Ȱ��ȭ
        SetActiveObjects(speakers[currentSpeakerIndex], true);

        // ���� ȭ�� �̸� �ؽ�Ʈ ����
        speakers[currentSpeakerIndex].textName.text = dialogs[currentDialogIndex].name;

        // ���� ȭ���� ��� �ؽ�Ʈ ����
        //speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue;
        StartCoroutine("OnTypingText");

    }

    private void SetActiveObjects(Speaker speaker, bool visivle)
    {
        speaker.imageDialog.gameObject.SetActive(visivle);
        speaker.textName.gameObject.SetActive(visivle);
        speaker.textDialogue.gameObject.SetActive(visivle);

        // ȭ��ǥ�� ��簡 ����Ǿ��� ���� Ȱ��ȭ �ϱ� ������ �׻� false
        speaker.objectArrow.SetActive(false);

        // ĳ���� ���� �� ����
        Color color = speaker.spriteRenderer.color;
        color.a = visivle == true ? 1 : 0.2f;
        speaker.spriteRenderer.color = color;
    }

    private IEnumerator OnTypingText()
    {
        int index = 0;

        isTypingEffect = true;

        // �ؽ�Ʈ�� �ѱ��ھ� Ÿ����ġ�� ���
        while ( index < dialogs[currentDialogIndex].dialogue.Length) 
        {
            speakers[currentSpeakerIndex].textDialogue.text = dialogs[currentDialogIndex].dialogue.Substring(0, index);

            index++;

            yield return new WaitForSeconds(typingSpeed);
        }
    }
}

[System.Serializable]
public struct Speaker
{
    public Image spriteRenderer; // ĳ���� �̹��� (û��/ȭ�� ���İ� ����)
    public Image imageDialog;             // ��ȭâ Image UI
    public TextMeshProUGUI textName;      // ���� ������� ĳ���� �̸� ��� Text UI
    public TextMeshProUGUI textDialogue;    // ���� ��� ��� Text UI
    public GameObject objectArrow;        // ��簡 �Ϸ� �Ǿ��� �� ��µǴ� Ŀ�� ������Ʈ

}

[System.Serializable]
public struct DialogData
{
    public int speakerIndex;              // �̸��� ��縦 ����� ���� DialogSystem�� speakers �迭 ����
    public string name;                   // ĳ���� �̸�
    [TextArea(3, 5)]
    public string dialogue;               // ���
}